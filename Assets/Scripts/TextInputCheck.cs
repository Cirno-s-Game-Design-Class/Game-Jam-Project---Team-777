using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextInputCheck : MonoBehaviour
{
    public TMP_InputField text;
    public Button sendButton;
    public int minimumWordCount;

    private void Update()
    {
        int wordCount = GetWordCount(text.text);
        if (wordCount >= minimumWordCount)
        {
            sendButton.interactable = true;
        }
    }

    int GetWordCount(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return 0;
        }
        string[] words = text.Split(new char[] { ' ', '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
    public void FinishEmail()
    {
        GameManager.emailsCount++;
    }
}
