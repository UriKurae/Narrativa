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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!stopCredits)
            credits.transform.Translate(0, -speed * Time.deltaTime, 0);

        if (credits.transform.position.y <= 730)
            stopCredits = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
