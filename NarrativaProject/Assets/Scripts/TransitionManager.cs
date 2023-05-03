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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            StartCoroutine(LoadNewScene());

        if (Input.GetKeyDown(KeyCode.F1))
        {
            ChangeScene("InteriorScene");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ChangeScene("BeachScene");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            ChangeScene("ShipScene");
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
}
