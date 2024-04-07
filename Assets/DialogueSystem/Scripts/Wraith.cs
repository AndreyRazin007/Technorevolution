using UnityEngine;

public class Wraith : NPC, ITalkable {
    [SerializeField] private DialogueText _dialogueText;

    public override void Interact() {
        Talk(_dialogueText);
    }

    public void Talk(DialogueText dialogueText) {
        
    }
}
