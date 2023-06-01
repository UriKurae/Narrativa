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

    public TransitionManager transitionManager;
    private bool fadeRequested = false;
    private float timeToActivateCamera = 2.0f;
    public Camera mainCamera;
    public Camera mainCamera2;
    public GameObject topBlack;
    public GameObject bottomBlack;

    // Start is called before the first frame update
    void Start()
    {
        //topBlack.SetActive(false);
        //bottomBlack.SetActive(false);
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
        if (transitionManager.fading)
        {
            timeToActivateCamera -= Time.deltaTime;

            if (timeToActivateCamera <= 0.0f)
            {
                mainCamera.gameObject.SetActive(false);
                mainCamera2.gameObject.SetActive(true);
                cameraCanyon.GetComponent<CanyonController>().CinematicCamera();


                timeToActivateCamera = 2.0f;
            }
        }
        else if (fadeRequested && !transitionManager.fading)
        {
            kraken.GetComponent<KrakenBehaviour>().Cinematic();
            cameraCanyon.GetComponent<CanyonController>().StartShake(7.0f);
            musicManager.ChangeMainMusic(1);
            CanyonController canyon = cameraCanyon.GetComponent<CanyonController>();
            canyon.StartShake(9.0f);
            fadeRequested = false;
        }
    }

    public void StartKrakenGame()
    {
        for (int i = 0; i < uiToDeactivate.Length; i++)
        {
            uiToDeactivate[i].SetActive(true);
        }
        transitionManager.RequestFade();
        fadeRequested = true;
        kraken.SetActive(true);
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
