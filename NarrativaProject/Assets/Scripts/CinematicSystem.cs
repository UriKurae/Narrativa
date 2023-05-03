using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CinematicSystem : MonoBehaviour
{
    public NPCConversation dialogue;
    private int currentSequenceImageIndex = 0;

    private bool changedImage = false;
    private bool fadeOut = false;
    private bool fadeIn = false;
    private bool scaling = false;
    private bool fadeAndStartGame = false;

    public List<GameObject> images;

    // Start is called before the first frame update
    void Start()
    {
        ConversationManager.Instance.StartConversation(dialogue);
        SelectCinematic(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (changedImage)
        {
            Image im = images[currentSequenceImageIndex].GetComponent<Image>();
            im.color = Color.white;
            changedImage = false;
            scaling = true;
        }

        if (fadeIn)
        {
            FadeIn(currentSequenceImageIndex);
        }

        if (fadeOut)
        {
            FadeOut(currentSequenceImageIndex);   
        }

        if (scaling)
        {
            RectTransform transformRect = images[currentSequenceImageIndex].GetComponent<RectTransform>();
            transformRect.localScale = new Vector3(transformRect.localScale.x + 0.01f * Time.deltaTime, transformRect.localScale.y + 0.01f * Time.deltaTime, transformRect.localScale.z + 0.01f * Time.deltaTime);
            Debug.Log(transform.localScale);
            if (transformRect.localScale.x >= 2.0f && transformRect.localScale.y >= 2.0f && transformRect.localScale.z >= 2.0f)
            { 
                scaling = false;
            }
        }

        if (fadeAndStartGame)
        {
            Image im = images[currentSequenceImageIndex].GetComponent<Image>();

            float r = (im.color.r - Time.deltaTime / 2.0f);
            float g = (im.color.g - Time.deltaTime / 2.0f);
            float b = (im.color.b - Time.deltaTime / 2.0f);

            im.color = new Color(r, g, b, 1.0f);
            if (im.color.r <= 0.0f && im.color.g <= 0.0f && im.color.b <= 0.0f)
            {
                SceneManager.LoadScene("BeachScene");
            }
        }

    }

    private bool FadeOut(int currentImageIndex)
    {
        bool finished = false;
        Image im = images[currentImageIndex].GetComponent<Image>();

        float r = (im.color.r + Time.deltaTime / 2.0f);
        float g = (im.color.g + Time.deltaTime / 2.0f);
        float b = (im.color.b + Time.deltaTime / 2.0f);

        im.color = new Color(r, g, b, 1.0f);

        if (im.color.r >= 1.0f && im.color.g >= 1.0f && im.color.b >= 1.0f)
        {
            fadeOut = false;
            finished = true;
        }
        return finished;
    }
    private bool FadeIn(int nextImageIndex)
    {
        bool finished = false;
        Image im = images[nextImageIndex - 1].GetComponent<Image>();

        float r = (im.color.r - Time.deltaTime / 2.0f);
        float g = (im.color.g - Time.deltaTime / 2.0f);
        float b = (im.color.b - Time.deltaTime / 2.0f);

        im.color = new Color(r, g, b, 1.0f);
        if (im.color.r <= 0.0f && im.color.g <= 0.0f && im.color.b <= 0.0f)
        {
            images[nextImageIndex].SetActive(true);
            im = images[nextImageIndex].GetComponent<Image>();
            im.color = Color.black;
            fadeOut = true;
            fadeIn = false;
            finished = true;
        }
        return finished;
    }
    public void SelectCinematic(int index)
    {
        fadeIn = false;
        fadeOut = false;
        scaling = false;
        changedImage = false;
        for (int i = 0; i < images.Count; ++i)
        {
            if (i == currentSequenceImageIndex)
                continue;

            images[i].SetActive(false);
        }
        
        changedImage = true;
        currentSequenceImageIndex = index;
        if (currentSequenceImageIndex != 0)
        {
            fadeIn = true;
        }
    }

    public void StartGame()
    {
        fadeAndStartGame = true;
        
    }
}
