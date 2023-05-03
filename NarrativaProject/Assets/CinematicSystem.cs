using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.UI;
public class CinematicSystem : MonoBehaviour
{
    public NPCConversation dialogue;
    private int currentSequenceImageIndex = 0;

    private bool changedImage = false;
    private bool fade = false;

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
            im.color = Color.black;
            changedImage = false;
            fade = true;
        }

        if (fade)
        {
            Image im = images[currentSequenceImageIndex].GetComponent<Image>();
           
            float r = (im.color.r + Time.deltaTime/2.0f);
            float g = (im.color.g + Time.deltaTime/2.0f);
            float b = (im.color.b + Time.deltaTime/2.0f);

            im.color = new Color(r,g,b,1.0f);
            
            if (im.color == Color.white)
                fade = false;
        }

    }

    public void SelectCinematic(int index)
    {
        for (int i = 0; i < images.Count; ++i)
        {
            images[i].SetActive(false);
        }

        images[index].SetActive(true);
        changedImage = true;
        currentSequenceImageIndex = index;
    }
}
