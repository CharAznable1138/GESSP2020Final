using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject nameDisplay;
    [SerializeField] GameObject dialogueDisplay;
    private Text nameDisplayText;
    private Text dialogueDisplayText;
    private Queue<string> sentences;
    [SerializeField] Animator animator;
    private bool isDialogueOver;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        nameDisplayText = nameDisplay.GetComponent<Text>();
        dialogueDisplayText = dialogueDisplay.GetComponent<Text>();
        isDialogueOver = false;
    }

    internal void StartDialogue(Dialogue _dialogue)
    {
        isDialogueOver = false;
        animator.SetBool("IsOpen", true);
        nameDisplayText.text = _dialogue.name;
        sentences.Clear();
        foreach(string sentence in _dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    internal void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string _sentence)
    {
        dialogueDisplayText.text = null;
        foreach(char letter in _sentence.ToCharArray())
        {
            dialogueDisplayText.text += letter;
            yield return null;
        }
    }

    internal void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        isDialogueOver = true;
    }

    internal bool IsDialogueOver { get { return isDialogueOver; } }
}
