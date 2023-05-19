using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        effect.SetActive(false);
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
            Destroy(this.gameObject, 5.0f);
       }
    }
}
