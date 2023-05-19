using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneDeadManager : MonoBehaviour
{
    public GameObject[] uiToDeactivate;
    public Image toFade;

    public float timeToShowUI = 5.0f;
    private bool showUI = false;

    public Animator anim;
    public Animation animationDead;

    public AudioSource audioDead;
    // Start is called before the first frame update
    void Start()
    {

        anim.SetTrigger("Dead");
       
        audioDead.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timeToShowUI -= Time.deltaTime;
        if (timeToShowUI <= 0.0f)
        {
            showUI = true;
        }

        if (showUI)
        {
            Color color = toFade.color;
            color.a -= Time.deltaTime;
            toFade.color = color;
            if (toFade.color.a <= 0.0f)
            {
                toFade.gameObject.SetActive(false);
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("ShipScene");
    }
}
