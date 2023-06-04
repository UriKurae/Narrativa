using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScene : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI winMessage;
    public TextMeshProUGUI credits;
    public float speed;
    private bool stopCredits = false;

    void Update()
    {

        if (!stopCredits)
            credits.transform.Translate(0, -speed * Time.deltaTime, 0);

        if (credits.transform.position.y <= 730)
            stopCredits = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
