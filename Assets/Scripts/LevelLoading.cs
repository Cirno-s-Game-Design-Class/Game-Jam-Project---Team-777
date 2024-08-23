using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    public Animator transition;
    public float loadDelay = 1f;
    void Update()
    {
        
    }

    public void LoadNext()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int index)
    {
        transition.SetTrigger("BeginCrossfade");
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(index);
    }
}
