using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextToDisplay : MonoBehaviour
{
    public DialogueSO _dialogueSO;
    public TextMeshPro _dialogueToDisplay;
    private void Start()
    {
        _dialogueToDisplay.text = _dialogueSO._textToDisplay;
    }
}