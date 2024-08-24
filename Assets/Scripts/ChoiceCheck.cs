using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceCheck : MonoBehaviour
{
    public Toggle correctAnswer;

    bool scoreCheckDone;
    Toggle chosenAnswer;
    Toggle lastAnswer;

    private void Update()
    {
        if (Scoring.callScore & !scoreCheckDone)
        {
            StartCoroutine(CountScore());
        }
    }

    public void UpdateChoice(Toggle Choice)
    {
        if (lastAnswer != null)
        {
            lastAnswer.isOn = false;
            Choice.interactable = false;
            lastAnswer.interactable = true;
            chosenAnswer = lastAnswer = Choice;
        }
        else
        {
            Choice.interactable = false;
            chosenAnswer = lastAnswer = Choice;
        }
    }

    IEnumerator CountScore()
    {
        yield return new WaitForEndOfFrame();
        if (correctAnswer == chosenAnswer)
        {
            Scoring.score += 1;
            scoreCheckDone = true;
        }
    }
}
