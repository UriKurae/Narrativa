using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject kraken;
    public GameObject player;
    public GameObject[] uiToDeactivate;
    public GameObject cameraCanyon;
    public GameObject canyon;

    public MusicManager musicManager;
    public Camera mainCamera;
    public Camera mainCamera2;

    // Start is called before the first frame update
    void Start()
    {
        canyon.SetActive(false);
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
        kraken.GetComponent<KrakenBehaviour>().Cinematic();
        cameraCanyon.GetComponent<CanyonController>().StartShake(7.0f);
        musicManager.ChangeMainMusic(1);
        mainCamera.gameObject.SetActive(false);
        mainCamera2.gameObject.SetActive(true);
        CanyonController canyon = cameraCanyon.GetComponent<CanyonController>();
        canyon.StartShake(9.0f);
       
        player.GetComponent<PlayerController>().canInteract = false;

    }

    public void EndGame()
    {
        SceneManager.LoadScene("DeadScene");
    }

    public void SetElectricShotAvailable()
    {
        canyon.SetActive(true);
        canyon.GetComponent<CanyonController>().electricShotAvailable = true;
        canyon.SetActive(false);
    }
}
