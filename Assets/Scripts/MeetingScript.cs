using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MeetingScript : MonoBehaviour
{
    public bool inCafe;
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
        if ((!inCafe))
        {
            bubbleTwo.color = Color.gray;
            bubbleThree.color = Color.gray;
        }
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

        if (inCafe)
        {
            if (Choice != correctAnswer[3] && corrects == 3)
            {
                Debug.Log("y");
                Choice.interactable = false;
            }

            if (Choice != correctAnswer[4] && corrects == 4)
            {
                Debug.Log("y");
                Choice.interactable = false;
            }
        }

        if (Choice == correctAnswer[0] && corrects == 0)
        {
            Debug.Log("yy");
            corrects = 1;
            StartCoroutine(ResetButtons());
        }

        if (Choice == correctAnswer[1] && corrects == 1)
        {
            Debug.Log("yy");
            corrects = 2;
            StartCoroutine(ResetButtons());
        }

        if (inCafe)
        {
            if (Choice == correctAnswer[2] && corrects == 2)
            {
                Debug.Log("yy");
                corrects = 3;
                StartCoroutine(ResetButtons());
            }
            if (Choice == correctAnswer[3] && corrects == 3)
            {
                Debug.Log("yy");
                corrects = 4;
                StartCoroutine(ResetButtons());
            }

            if (Choice != correctAnswer[3] && corrects == 4)
            {
                Debug.Log("yyy");
                GameManager.meetingDone = true;
                LevelLoader.LoadSceneWithValue(9);
            }
        }
        else
        {
            if (Choice == correctAnswer[2] && corrects == 2)
            {
                Debug.Log("yyy");
                GameManager.meetingDone = true;
                LevelLoader.LoadSceneWithValue(1);
            }
        }
        if (!inCafe)
        {
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
        else
        {
            if (corrects == 1)
            {
                correctSprites[1].gameObject.SetActive(true);
            }
            if (corrects == 2)
            {
                correctSprites[2].gameObject.SetActive(true);
            }
            if (corrects == 3)
            {
                correctSprites[3].gameObject.SetActive(true);
            }
            if (corrects == 4)
            {
                correctSprites[4].gameObject.SetActive(true);
            }
            if (corrects == 5)
            {
                correctSprites[5].gameObject.SetActive(true);
            }
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
