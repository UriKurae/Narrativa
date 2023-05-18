using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenBehaviour : MonoBehaviour
{
    public float shotDelay = 3.0f;
    public GameObject tint;
    public Transform shootLocation;
    private Animator anim;

    public bool alive = true;
    public int healthPoints = 100;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        shotDelay -= Time.deltaTime;

        if (shotDelay <= 0.0f && alive)
        {
            ShootTint();
            shotDelay = 3.0f;
        }
    }

    public void ShootTint()
    {
        string attack = "Attack_" + Random.Range(1, 5);
        anim.SetTrigger(attack);
        Instantiate(tint, shootLocation.position, shootLocation.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cannon")
        {
            healthPoints -= 10;
            if (healthPoints <= 0)
            {
                Die();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }

    private void Die()
    {
        alive = false;
        anim.SetTrigger("Die");
    }
}
