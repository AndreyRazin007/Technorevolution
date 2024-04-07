using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/New Dialogue Container")]
public class DialogueText : ScriptableObject {
    [SerializeField] private string _speakerName;

    [TextArea(5, 10)]
    [SerializeField] private string[] _paragraphs;
}
