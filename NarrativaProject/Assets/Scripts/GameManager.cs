using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject kraken;

    // Start is called before the first frame update
    void Start()
    {
        kraken.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartKrakenGame()
    {
        kraken.SetActive(true);
    }
}
