using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeScene("InteriorScene");
        }
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
