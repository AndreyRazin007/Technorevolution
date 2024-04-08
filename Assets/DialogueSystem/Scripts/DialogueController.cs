using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _npcNameText;
    [SerializeField] private TextMeshProUGUI _npcDialogueText;
    [SerializeField] private float _typeSpeed = 10.0f;

    private Queue<string> _paragraphs = new();

    private bool _conversationEnded;

    private bool _isTyping;

    private string _paragraph;

    private Coroutine _typeDialogueCoroutine;

    private const string HTML_ALPHA = "<color=#00000000>";
    private const float MAX_TYPE_TIME = 0.1f;

    private void StartConversation(DialogueText dialogueText) {
        if (!gameObject.activeSelf) {
            gameObject.SetActive(true);
        }

        _npcNameText.text = dialogueText.SpeakerName;

        for (int i = 0; i < dialogueText.Paragraphs.Length; ++i) {
            _paragraphs.Enqueue(dialogueText.Paragraphs[i]);
        }
    }

    private void EndConversation() {
        _conversationEnded = false;

        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator TypeDialogueText(string paragraph) {
        _isTyping = true;

        _npcDialogueText.text = "";

        string originalText = paragraph;
        string displayedText = "";
        int alphaIndex = 0;

        foreach (char symbol in paragraph.ToCharArray()) {
            ++alphaIndex;
            _npcDialogueText.text = originalText;

            displayedText = _npcDialogueText.text.Insert(alphaIndex, HTML_ALPHA);
            _npcDialogueText.text = displayedText;

            yield return new WaitForSeconds(MAX_TYPE_TIME / _typeSpeed);
        }

        _isTyping = false;
    }

    private void FinishParagraphEarly() {
        StopCoroutine(_typeDialogueCoroutine);

        _npcDialogueText.text = _paragraph;

        _isTyping = false;
    }

    public void DisplayNextParagraphs(DialogueText dialogueText) {
        if (_paragraphs.Count == 0) {
            if (!_conversationEnded) {
                StartConversation(dialogueText);
            } else if (_conversationEnded && !_isTyping) {
                EndConversation();
                return;
            }
        }

        if (!_isTyping) {
            _paragraph = _paragraphs.Dequeue();
            _typeDialogueCoroutine = StartCoroutine(TypeDialogueText(_paragraph));
        } else {
            FinishParagraphEarly();
        }

        if (_paragraphs.Count == 0) {
            _conversationEnded = true;
        }
    }
}
