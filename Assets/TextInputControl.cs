using UnityEngine;
using TMPro; // Add this namespace to use TextMesh Pro components
using System.Linq;

public class TextInputControl : MonoBehaviour
{
    public TMP_InputField inputField; // Change to TMP_InputField
    public TextMeshProUGUI wordLimitText; // Change to TextMeshProUGUI
    public int maxWordCount = 50;

    void Start()
    {
        inputField.onValueChanged.AddListener(DelegateMethod);
        UpdateWordCount();
    }

    void DelegateMethod(string input)
    {
        UpdateWordCount();
    }

    void UpdateWordCount()
    {
        int wordCount = inputField.text.Split(new char[] { ' ', '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
        wordLimitText.text = wordCount + "/" + maxWordCount;

        if (wordCount >= maxWordCount)
        {
            inputField.text = string.Join(" ", inputField.text.Split(new char[] { ' ', '\n' }, System.StringSplitOptions.RemoveEmptyEntries).Take(maxWordCount));
        }
    }
}