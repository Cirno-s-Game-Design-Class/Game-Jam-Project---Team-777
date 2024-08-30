using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkGameScript : MonoBehaviour
{
    public LevelLoader SceneLoader;
    public Toggle[] answers = new Toggle[4];
    public Toggle[] correctAnswers = new Toggle[2];
    public GameObject[] correctSprites;
    public int scores;
    bool a;

    public void UpdateChoice(Toggle Choice)
    {
        scores++;
        Choice.interactable = false;
    }
    private void Update()
    {
        if (scores == 2 && !a)
        {
            for (int i = 0; i < correctSprites.Length; i++)
            {
                correctSprites[i].SetActive(true);
                StartCoroutine(go());
                a = true;
            }
        }
    }
    IEnumerator go()
    {

        yield return new WaitForEndOfFrame();
        SceneLoader.LoadSceneWithValue(6);
    }
}
