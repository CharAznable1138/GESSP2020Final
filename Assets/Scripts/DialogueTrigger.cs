using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] GameObject dialogueManagerObject;
    private DialogueManager dialogueManager;
    [SerializeField] Dialogue dialogue;
    [SerializeField] float startDialogueDelay = 0.5f;
    private void Start()
    {
        dialogueManager = dialogueManagerObject.GetComponent<DialogueManager>();
        StartCoroutine(StartDialogueAfterDelay());
    }
    internal void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            dialogueManager.DisplayNextSentence();
        }
    }
    IEnumerator StartDialogueAfterDelay()
    {
        yield return new WaitForSeconds(startDialogueDelay);
        TriggerDialogue();
    }
}
