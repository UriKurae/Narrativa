using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    private bool canTriggerDialogue = false;
    private GameObject npcDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canTriggerDialogue && Input.GetKeyUp(KeyCode.E))
        {
            TriggerDialogue td = npcDialogue.GetComponent<TriggerDialogue>();

            if (td)
            {
                td.StartConversation();
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Npc")
        {
            canTriggerDialogue = true;
            npcDialogue = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Npc")
        {
            canTriggerDialogue = false;
            npcDialogue = other.gameObject;
        }
    }
}
