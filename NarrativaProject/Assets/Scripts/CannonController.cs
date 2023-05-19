using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject shootObject;
    //private GameObject origin;
    //private Quaternion originalRotation;
    public float force = 10f;
    public float rotationSensitivity = 10f;
    //private AudioSource cannonShootAudio;
    // Start is called before the first frame update
    void Start()
    {
        //origin = this.transform.GetChild(0).gameObject;
        //originalRotation = this.gameObject.transform.rotation;
        //cannonShootAudio = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // GameObject it = Instantiate(shootObject, origin.transform.position, gameObject.transform.rotation);
           // it.GetComponent<Rigidbody>().AddForce(this.transform.right * force, ForceMode.Impulse);
           // Destroy(it, 7.0f);
           //
           // cannonShootAudio.Play();
        }

        //Rotate Down
       // if (Input.GetKey(KeyCode.DownArrow))
       // {
       //     this.transform.Rotate(0.0f,0.0f, -rotationSensitivity * Time.deltaTime);
       // }
       // //Rotate Up
       // if (Input.GetKey(KeyCode.UpArrow))
       // {
       //     this.transform.Rotate(0.0f,0.0f, rotationSensitivity * Time.deltaTime);
       // }
       // //Rotate Left
       // if (Input.GetKey(KeyCode.LeftArrow))
       // {
       //     this.transform.Rotate(0.0f, -rotationSensitivity * Time.deltaTime, 0.0f);
       // }
       // //Rotate Right
       // if (Input.GetKey(KeyCode.RightArrow))
       // {
       //     this.transform.Rotate(0.0f, rotationSensitivity * Time.deltaTime, 0.0f);
       // }
       //
       // //Reset Rotation
       // if (Input.GetKey(KeyCode.R))
       // {
       //     this.transform.rotation = originalRotation;
       // }
    }
}