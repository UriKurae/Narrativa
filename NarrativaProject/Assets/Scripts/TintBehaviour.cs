using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintBehaviour : MonoBehaviour
{
    public GameObject target;
    public GameObject rocket;

    public float rotationSpeedProjectile = 300.0f;
    public float SpeedProjectile = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("CannonGame");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.transform);
        this.transform.Translate(0.0f, 0.0f, SpeedProjectile * Time.deltaTime);

        rocket.transform.RotateAround(this.transform.position, this.transform.forward, 300.0f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cannon")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cannon")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject.Find("Denki").GetComponent<PlayerController>().GetHit();
        }
    }
}
