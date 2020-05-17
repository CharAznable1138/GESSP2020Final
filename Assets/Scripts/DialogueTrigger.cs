using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] GameObject dialogueManagerObject;
    private DialogueManager dialogueManager;
    [SerializeField] Dialogue dialogue;
    [SerializeField] float startDialogueDelay = 0.5f;
    [SerializeField] GameObject dialogueDisplay;
    private Text dialogueDisplayText;
    private void Start()
    {
        dialogueManager = dialogueManagerObject.GetComponent<DialogueManager>();
        dialogueDisplayText = dialogueDisplay.GetComponent<Text>();
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
            dialogueDisplayText.text = null;
            dialogueManager.DisplayNextSentence();
        }
    }
    IEnumerator StartDialogueAfterDelay()
    {
        yield return new WaitForSeconds(startDialogueDelay);
        TriggerDialogue();
    }
}
