using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float loadDelay = 1f;
    public int specificScene = 0;

    public void LoadScene()
    {
        if (specificScene != 0)
            StartCoroutine(Processing(specificScene));
        else
            StartCoroutine(Processing(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadSceneWithValue(int index)
    {
        StartCoroutine(Processing(index));
    }

    IEnumerator Processing(int index)
    {
        transition.SetTrigger("BeginFade");
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(index);  
    }
}
