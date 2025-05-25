using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class DialogueText : MonoBehaviour
{
    [SerializeField] private TMP_Text _mainText;
    private bool _isPrint;

    private void Start()
    {
        RevealText(" огда € увидел то существо, € сильно удивилс€.", 0.05f, false);
    }

    public void RevealText(string currentText, float delay, bool skipped)
    {
        StartCoroutine(TextPrint(_mainText, currentText, delay, skipped));
    }

    IEnumerator TextPrint(TMP_Text textObject, string currentText, float delay, bool skipped)
    {
        if (_isPrint) yield return null;
        
        _isPrint = true;

        for (int i = 0; i <= currentText.Length; i++)
        {
            if (skipped) 
            {
                textObject.text = currentText;
                yield return null; 
            }

            _mainText.text = currentText.Substring(0, i);

            yield return new WaitForSeconds(delay);
        }

        _isPrint = false;
    }

}
