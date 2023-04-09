using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
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
}
