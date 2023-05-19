using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KrakenBehaviour : MonoBehaviour
{
    public float shotDelay = 3.0f;
    public GameObject tint;
    public Transform shootLocationRight;
    public Transform shootLocationLeft;
    public Transform shootLocationMiddle;
    public Transform shootLocationTop;
    private Animator anim;

    private float delayHit = 0.0f;
    private bool hit = false;
    private bool changedImage = false;
    public GameObject healthBar;
    public GameObject imageKraken;
    public Sprite[] images;

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
            if (healthPoints > 75)
            {
                shotDelay = 3.0f;
            }
            else if (healthPoints > 50)
            {
                shotDelay = 1.5f;

            }
            else if (healthPoints > 25)
            {
                shotDelay = 0.5f;

            }
        }


        if (hit && changedImage == false)
        {
            imageKraken.GetComponent<Image>().sprite = images[1];
            delayHit = 0.1f;
            changedImage = true;
        }

        if (changedImage)
        {

            delayHit -= 0.25f * Time.deltaTime;
        }

        if (delayHit <= 0.0f)
        {
            hit = false;
            changedImage = false;
            imageKraken.GetComponent<Image>().sprite = images[0];
        }
       

    }

    public void ShootTint()
    {
        int number = Random.Range(1, 5);
        string attack = "Attack_" + number;
        anim.SetTrigger(attack);

        if (number == 1 || number == 2)
        {
            Instantiate(tint, shootLocationLeft.position, shootLocationLeft.rotation);

        }
        else if (number == 3)
        {
            Instantiate(tint, shootLocationRight.position, shootLocationRight.rotation);
        }
        else if (number == 4)
        {
            Instantiate(tint, shootLocationMiddle.position, shootLocationMiddle.rotation);
        }
        else
        {
            Instantiate(tint, shootLocationTop.position, shootLocationTop.rotation);
        }

        
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cannon")
        {
            healthPoints -= 1;

            Vector2 curr = healthBar.GetComponent<RectTransform>().sizeDelta;
            float newHpWidth = healthPoints * 285.0f / 100.0f;

            healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(newHpWidth, curr.y);

            hit = true;
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
