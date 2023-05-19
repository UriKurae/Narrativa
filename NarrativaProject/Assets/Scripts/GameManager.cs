using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject kraken;
    public GameObject[] uiToDeactivate;

    // Start is called before the first frame update
    void Start()
    {
        kraken.SetActive(false);
        for (int i = 0; i < uiToDeactivate.Length; i++)
        {
            uiToDeactivate[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartKrakenGame()
    {
        for (int i = 0; i < uiToDeactivate.Length; i++)
        {
            uiToDeactivate[i].SetActive(true);
        }
        kraken.SetActive(true);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("DeadScene");
    }
}
