using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public TextMeshProUGUI textProgress;
    public Slider sliderProgress;

    // Update is called once per frame
    private void Update()
    {
        if (Input.anyKey)
        {
            StartCoroutine(LoadNewScene());
        }
    }

    private IEnumerator LoadNewScene()
    {
        sliderProgress.gameObject.SetActive(true);
        //AsyncOperation operationLoad = SceneManager

        yield return null;
    }
}
