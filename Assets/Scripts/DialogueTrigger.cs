using UnityEngine;
using UnityEngine.UI;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool isInRange;

    private GameObject interactUI;
    private bool isTalking = false;

    public Text revealInteractUISymbol;

    private void Awake()
    {
        revealInteractUISymbol = GameObject.FindGameObjectWithTag("interactUI").GetComponent<Text>();
    }
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E) && !isTalking)
        {
            TriggerDialogue();
        }else if(isInRange && Input.GetKeyDown(KeyCode.E) && isTalking)
        {
            DialogueManager.dialogueManager.DisplayNextSentence();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            revealInteractUISymbol.enabled = true;
            isInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            revealInteractUISymbol.enabled = false;
            isInRange = false;
            isTalking = false;
            DialogueManager.dialogueManager.EndDialogue();
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.dialogueManager.StartDialogue(dialogue);
        isTalking = true;
    }

}
