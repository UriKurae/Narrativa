using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class TriggerDialogue : MonoBehaviour
{
    public NPCConversation dialogue;

    
    public void StartConversation()
    {
        ConversationManager.Instance.StartConversation(dialogue);
    }

    public void EndConversation()
    {
        ConversationManager.Instance.EndConversation();
    }

}
