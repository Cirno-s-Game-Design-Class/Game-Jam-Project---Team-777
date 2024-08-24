using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MeetingScript : MonoBehaviour
{
    public LevelLoader LevelLoader;
    public SpriteRenderer bubbleOne;
    public SpriteRenderer bubbleTwo;
    public SpriteRenderer bubbleThree;
    public Toggle[] correctAnswer = new Toggle[3];
    public Toggle[] answers = new Toggle[4];
    public GameObject[] dotdotdot = new GameObject[2];
    public SpriteRenderer[] correctSprites = new SpriteRenderer[3];

    int corrects = 0;
    Toggle lastAnswer;

    private void Start()
    {
        bubbleTwo.color = Color.gray;
        bubbleThree.color = Color.gray;
    }

    public void UpdateChoice(Toggle Choice)
    {
        if (Choice != correctAnswer[0] && corrects == 0)
        {
            Debug.Log("y");
            Choice.interactable = false;
        }

        if (Choice != correctAnswer[1] && corrects == 1)
        {
            Debug.Log("y");
            Choice.interactable = false;
        }

        if (Choice != correctAnswer[2] && corrects == 2)
        {
            Debug.Log("y");
            Choice.interactable = false;
        }

        if (Choice == correctAnswer[0] && corrects == 0)
        {
            Debug.Log("yy");
            corrects++;
            StartCoroutine(ResetButtons());
        }

        if (Choice == correctAnswer[1] && corrects == 1)
        {
            Debug.Log("yy");
            corrects++;
            StartCoroutine(ResetButtons());
        }

        if (Choice == correctAnswer[2] && corrects == 2)
        {
            Debug.Log("yyy");
            GameManager.meetingDone = true;
            LevelLoader.LoadSceneWithValue(2);
        }

        if (corrects == 1)
        {
            correctSprites[0].enabled = false;
            bubbleOne.color = Color.gray;
            bubbleTwo.color = Color.white;
            dotdotdot[0].SetActive(false);
            correctSprites[1].enabled = true;
        }

        if(corrects == 2)
        {
            correctSprites[1].enabled = false;
            bubbleTwo.color = Color.gray;
            bubbleThree.color = Color.white;
            dotdotdot[1].SetActive(false);
            correctSprites[2].enabled = true;
        }
    }

    IEnumerator ResetButtons()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].interactable = true;
        }
    }
}
