using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TintBehaviour : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("CannonGame");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.transform);
        this.transform.Translate(0.0f, 0.0f, 20.0f * Time.deltaTime);
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
            Destroy(other.gameObject);
        }
    }
}
