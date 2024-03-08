using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class David : NPC, ITalkable
{

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueController dialogueController;
    


    public override void Interact()
    {
        Talk(dialogueText);
        
    }
   

    public void Talk(DialogueText dialogueText)
    {
        // lancement de la conversation
        dialogueController.DisplayNextParagraph (dialogueText);
    }

}
