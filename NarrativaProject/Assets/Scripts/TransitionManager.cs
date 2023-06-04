using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public TextMeshProUGUI progressText;
    public Slider progressSlider;

    bool fadeRequested = false;
    public GameObject transitionCanvas;
    bool fadeIn = false;
    bool fadeOut = false;

    [HideInInspector]
    public bool fading = false;


    public enum TypeScene
    {
        DEFAULT = 0,
        BEACH_S = 1,
        SHIP_S = 2,
        INSIDE_SHIP_S = 3

    }

    TypeScene requestScene = TypeScene.DEFAULT;

    private void Start()
    {
        transitionCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeRequested)
        {
            transitionCanvas.SetActive(true);
            Fade();

            if (requestScene != TypeScene.DEFAULT)
            {
                if (Input.GetKeyDown(KeyCode.L))
                    StartCoroutine(LoadNewScene());

                if (Input.GetKeyDown(KeyCode.F1) || requestScene == TypeScene.INSIDE_SHIP_S)
                {
                    ChangeScene("InteriorScene");
                }
                if (Input.GetKeyDown(KeyCode.F2) || requestScene == TypeScene.BEACH_S)
                {
                    ChangeScene("BeachScene");
                }
                if (Input.GetKeyDown(KeyCode.F3) || requestScene == TypeScene.SHIP_S)
                {
                    ChangeScene("ShipScene");
                }
            }
        }

    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private IEnumerator LoadNewScene()
    {
        progressSlider.gameObject.SetActive(true);
        AsyncOperation operationLoad = SceneManager.LoadSceneAsync(1);

        while (operationLoad.isDone != true)
        {
            float progress = Mathf.Clamp01(operationLoad.progress / .00f);
            progressSlider.value = progress;
            progressText.text = (progress * 100) + "%";

            yield return null;
        }

    }

    public void RequestFade()
    {
        fadeRequested = true;
        fadeIn = true;
        fading = true;
    }

    public void SelectChangeScene(int scene)
    {

        requestScene = (TypeScene)scene;
        RequestFade();

    }

    void Fade()
    {
        if (fadeIn)
        {
            float canvas = transitionCanvas.GetComponent<Image>().color.a;

            float a = (canvas + Time.deltaTime / 2.0f);

            Color test = transitionCanvas.GetComponent<Image>().color;

            transitionCanvas.GetComponent<Image>().color = new Color(test.r, test.g, test.b, a);
            if (a >= 1.0f)
            {
                fadeIn = false;
                fadeOut = true;
            }
        }

        if (fadeOut)
        {
            float canvas = transitionCanvas.GetComponent<Image>().color.a;

            float a = (canvas - Time.deltaTime / 2.0f);

            Color test = transitionCanvas.GetComponent<Image>().color;

            transitionCanvas.GetComponent<Image>().color = new Color(test.r, test.g, test.b, a);
            if (a <= 0.0f)
            {
                fadeIn = false;
                fadeOut = false;
                transitionCanvas.SetActive(false);
                fading = false;
            }
        }


    }
}
