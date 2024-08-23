using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextInputCheck : MonoBehaviour
{
    public List<TMP_InputField> answerFields;

    private void Start()
    {
        answerFields = new List<TMP_InputField>(FindObjectsOfType<TMP_InputField>());
        foreach (var field in answerFields)
        {
            if (field.tag != "Answer Field")
            {
                answerFields.Remove(field);
            }
        }
    }

    public void Lock()
    {
        StartCoroutine(SelectDelay());
    }

    public void Unlock()
    {
        foreach (var field in answerFields)
        {
            field.interactable = true;
        }
    }

    IEnumerator SelectDelay()
    {
        yield return new WaitForEndOfFrame(); foreach (var field in answerFields)
        {
            if (!field.isFocused)
            {
                field.interactable = false;
            }
        }
    }
}
