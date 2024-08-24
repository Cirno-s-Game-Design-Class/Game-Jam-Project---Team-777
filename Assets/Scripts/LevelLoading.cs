using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    public Animator transition;
    public float loadDelay = 1f;
    public int specificScene = -1;

    private void Start()
    {
        if (gameObject.name == "Crossfade")
            transition = GetComponent<Animator>();
        
    }

    public void LoadNext()
    {
        if (specificScene != -1)
            StartCoroutine(LoadLevel(specificScene));
        else
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int index)
    {
        transition.SetTrigger("BeginCrossfade");
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(index);
    }
}
