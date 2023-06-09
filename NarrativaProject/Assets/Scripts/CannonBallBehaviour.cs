using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    public GameObject effect;
    public GameObject tintEffect;
    // Start is called before the first frame update
    void Start()
    {
        effect.SetActive(false);
        tintEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Kraken")
       {
            effect.SetActive(true);
            effect.gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject, 5.0f);
       }
        if (other.gameObject.tag == "Tint")
        {
            tintEffect.SetActive(true);
            tintEffect.gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject, 5.0f);
        }
    }
}
