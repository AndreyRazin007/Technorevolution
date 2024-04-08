using UnityEngine;

public class Wraith : NPC, ITalkable {
    [SerializeField] private DialogueText _dialogueText;
    [SerializeField] private DialogueController _dialogueController;

    public override void Interact() {
        Talk(_dialogueText);
    }

    public void Talk(DialogueText dialogueText) {
        _dialogueController.DisplayNextParagraphs(dialogueText);
    }
}
