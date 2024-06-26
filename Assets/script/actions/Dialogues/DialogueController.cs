using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.UI;


public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private Image NPCFace;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private float typeSpeed = 10;

    private Queue<string> paragraphs = new Queue<string>();
    private bool IsTyping;
    private bool conversatioEnded;
    private string p;
    private Coroutine typeDialogueCoroutine;
    private const string HtmlAlpha = "<color=#00000000>";
    private const float MaxTypeTime = 0.1f;
    public bool CanMove = true;
    public Player_Mouvements YouCanMove;
    [SerializeField] private AudioClip DialogueSound;


    public void DisplayNextParagraph (DialogueText dialogueText)
    {
        //---------------------- freeing the player during the dialogue ----------------------
        YouCanMove.stopMouvement();
        if (conversatioEnded == true)
        {
            YouCanMove.playMouvement();
        }

        //-------------- if nothing is in the queue-----------

        if (paragraphs.Count == 0) 
        {
            if (!conversatioEnded)
            {
                
                
                //------------Start dialogue-------------
                StartConversaiton(dialogueText);
                


            }
            else if (conversatioEnded && !IsTyping)
            {

                //--------------- End Dialogue-------------
                EndConversaiton();
                
            
                return;
                
            }
        
        }
        //-------------- if there is something in the queue----------
        if (!IsTyping)
        {
            YouCanMove.stopMouvement();
            p = paragraphs.Dequeue();
            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));

        }
        // the Text is beeing typed out
        else
        {
            YouCanMove.stopMouvement();
            FinishParagraphUrly();

        }

        // ---------- uptdate conversationEnded Bool ----------
        if (paragraphs.Count == 0 )
        {
            YouCanMove.stopMouvement();
            conversatioEnded = true;

        }


    }
    private void StartConversaiton (DialogueText dialogueText)
    {
        YouCanMove.stopMouvement();
        //------------ activate gameObject -----------------
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Sound_Manager.instance.playSoundDXClip(DialogueSound, transform, 0.2f);

        }
        NPCFace.sprite = dialogueText.NPCFace;
        //---------------uptate the NPC's Name---------

        NPCNameText.text = dialogueText.NPCName;
        //---------------- add dialogue Text to the queue------------
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {

            paragraphs.Enqueue(dialogueText.paragraphs[i]); 
        }
    }
    private void EndConversaiton()
    {
        //------------clear the Queue------------
        paragraphs.Clear();
        //--------------returne bool to false------------
        conversatioEnded = false;
        //----------------- deactivetate gameObject---------
        if (gameObject.activeSelf)
        {

            gameObject.SetActive(false);
        }
     
       

    }
    private IEnumerator TypeDialogueText(string p)
    {
        // setting an alpha object just befor the text the making it go down each letter
        //to make them appeare. It allow us to make appeare the text in a way smother way.
        IsTyping = true;
        NPCDialogueText.text = "";
        string originalText = p;
        string displayedText= "";
        int alphaIndex = 0;
        YouCanMove.stopMouvement();
        foreach (char c in p.ToCharArray())
        { 
            alphaIndex++;
            NPCDialogueText.text = originalText;


            displayedText = NPCDialogueText.text.Insert(alphaIndex, HtmlAlpha);
            NPCDialogueText.text = displayedText;
            yield return new WaitForSeconds(MaxTypeTime/typeSpeed);
        }


        
        IsTyping = false;

    }
    // What if we press the key befor the text appared
    private void FinishParagraphUrly ()
    {

        // stop the coroutine
        StopCoroutine(typeDialogueCoroutine);
        // finish displaying the text
        NPCDialogueText.text = p;
        // uptdate Istyping bool
        IsTyping = false;
        



    }
}
