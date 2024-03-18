using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public bool isDialogueActive = false;
    public float typingSpeed = 0.2f;
    public Animator animator;
    public static DialogueManager instance;
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;


    private Queue<DialogueLine> lines;


    private void Start()
    {
        if (instance == null)
            instance = this;


    }


    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("on est la ");
        isDialogueActive=true;
        animator.Play("Show");
       lines.Clear();
        foreach (DialogueLine dialogueline in dialogue.dialogueLines) 
        { 
        
            lines.Enqueue(dialogueline);

        }
        
        DisplayNextDialogueLine();
    }
    public void DisplayNextDialogueLine()
    {
        Debug.Log("phrase suivante");
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        
        }
        DialogueLine currentLine = lines.Dequeue();
        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));


    }
    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }


    }
    void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("hide");
    }
}
