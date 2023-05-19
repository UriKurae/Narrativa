using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanyonController : MonoBehaviour
{
    public GameObject projectile;
    public float cameraSpeed = 50.0f;
    private bool canyonOrder = true;

    public float shotAvailableDelay = 0.2f;

    public AudioClip[] shotClips;
    public AudioSource audioCanyon;

    public Transform leftShot;
    public Transform rightShot;
   
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

        if (Input.GetKeyUp(KeyCode.Mouse0) && shotAvailableDelay <= 0.0f)
        {
            shotAvailableDelay = 0.2f;
            ShootProjectile();
        }

        shotAvailableDelay -= Time.deltaTime;

    }

    public void ShootProjectile()
    {
        canyonOrder = !canyonOrder;
        if (canyonOrder)
        {
            GameObject shot = Instantiate(projectile, leftShot.position, this.transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(this.transform.forward * 20.0f, ForceMode.Impulse);
        }
        else
        {
            GameObject shot = Instantiate(projectile, rightShot.position, this.transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(this.transform.forward * 20.0f, ForceMode.Impulse);
        }

        audioCanyon.clip = shotClips[Random.Range(0, shotClips.Length)];
        audioCanyon.Play();
    }
}
