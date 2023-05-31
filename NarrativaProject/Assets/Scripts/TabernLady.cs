using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabernLady : MonoBehaviour
{
    private bool sleep = false;
    private bool fadeIn = true;
    private bool fadeOut = true;
    public GameObject blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sleep)
        {
            if (fadeIn)
            {
                float canvas = blackScreen.GetComponent<Image>().color.a;             

                float a = (canvas + Time.deltaTime / 2.0f);

                Color test = blackScreen.GetComponent<Image>().color;

                blackScreen.GetComponent<Image>().color = new Color(test.r, test.g, test.b, a);
                if (a >= 1.0f)
                {
                    fadeIn = false;
                    fadeOut = true;
                }
            }

            if (fadeOut)
            {
                float canvas = blackScreen.GetComponent<Image>().color.a;

                float a = (canvas - Time.deltaTime / 2.0f);

                Color test = blackScreen.GetComponent<Image>().color;

                blackScreen.GetComponent<Image>().color = new Color(test.r, test.g, test.b, a);
                if (a <= 0.0f)
                {
                    fadeIn = false;
                    fadeOut = false;
                    sleep = false;
                    blackScreen.SetActive(false);
                }
            }


        }
    }

    public void Sleep()
    {
        blackScreen.SetActive(true);
        blackScreen.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        sleep = true;
        fadeIn = true;
        fadeOut = false;
    }
}
