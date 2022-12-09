using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextToDisplay : MonoBehaviour
{
    public DialogueSO _dialogueSO;
    public TextMeshPro _dialogueToDisplay;
    public List<DialogueSO> _dialogueForThis;
    public GameObject _parentOfThis;

    private void Awake()
    {
        _parentOfThis = gameObject.transform.parent.gameObject;
    }


    private void Start()
    {
        StartCoroutine(NextTextPlease());
    }

    IEnumerator NextTextPlease()
    {
        foreach (DialogueSO DialogueText in _dialogueForThis)
        {
            _dialogueToDisplay.text = DialogueText._textToDisplay;
            yield return new WaitForSeconds(6f);

            if (_dialogueForThis.IndexOf(DialogueText) == _dialogueForThis.Count -1)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(0).GetComponent<TextMeshPro>().enabled = false;
                yield return new WaitForSeconds(1f);
                _parentOfThis.GetComponent<Rigidbody>().AddForce(0f, 25, 0f, ForceMode.Impulse);
                yield return new WaitForSeconds(1f);
                _parentOfThis.SetActive(false);
            }
        }

        StopCoroutine(NextTextPlease());
    }
}