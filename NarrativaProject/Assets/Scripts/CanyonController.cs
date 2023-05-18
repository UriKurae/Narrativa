using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanyonController : MonoBehaviour
{
    public GameObject projectile;
    public float cameraSpeed = 50.0f;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Rotate(0.0f, -cameraSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Rotate(0.0f, cameraSpeed * Time.deltaTime, 0.0f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Rotate(-cameraSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Rotate(cameraSpeed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ShootProjectile();
        }
    }

    public void ShootProjectile()
    {
        GameObject shot = Instantiate(projectile, this.transform.position, this.transform.rotation);
        shot.GetComponent<Rigidbody>().AddForce(this.transform.forward * 20.0f, ForceMode.Impulse);
    }
}
