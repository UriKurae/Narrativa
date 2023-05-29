using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject kraken;
    public GameObject[] uiToDeactivate;
    public GameObject cameraCanyon;
    public GameObject blackScreen;
    
    public MusicManager musicManager;
    public Camera mainCamera;
    public Camera mainCamera2;

    bool dipToBlack = false;
    bool dipToWhite = false;

    // Start is called before the first frame update
    void Start()
    {
        Color color = blackScreen.GetComponent<Image>().material.color;
        color.a = 0.0f;
        blackScreen.GetComponent<Image>().material.color = color;

        kraken.SetActive(false);
        for (int i = 0; i < uiToDeactivate.Length; i++)
        {
            uiToDeactivate[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dipToBlack)
        {
            Color color = blackScreen.GetComponent<Image>().color;
            color.a += 0.2f * Time.deltaTime;
            blackScreen.GetComponent<Image>().color = color;

            if (blackScreen.GetComponent<Image>().material.color.a >= 0.0f)
            {
                dipToBlack = false;
                dipToWhite = true;
            }
        }
        if (dipToWhite)
        {
            Color color = blackScreen.GetComponent<Image>().color;
            color.a -= 0.2f * Time.deltaTime;
            blackScreen.GetComponent<Image>().color = color;

            if (blackScreen.GetComponent<Image>().color.a <= 0.0f)
            {
                dipToBlack = false;
                dipToWhite = false;
            }
        }
    }

    public void StartKrakenGame()
    {
        for (int i = 0; i < uiToDeactivate.Length; i++)
        {
            uiToDeactivate[i].SetActive(true);
        }
        kraken.SetActive(true);
        kraken.GetComponent<KrakenBehaviour>().Cinematic();
        musicManager.ChangeMainMusic(1);
        mainCamera.gameObject.SetActive(false);
        mainCamera2.gameObject.SetActive(true);
        CanyonController canyon = cameraCanyon.GetComponent<CanyonController>();
        canyon.StartShake(7.0f);
        SceneDipToBlack();
    }

    public void EndGame()
    {
        SceneManager.LoadScene("DeadScene");
    }

    public void SceneDipToBlack()
    {
       dipToBlack = true;
    }
}
