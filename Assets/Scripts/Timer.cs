using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public LevelLoader thingy;
    public Image Image;
    
    public void changeScene()
    {
        Image.gameObject.SetActive(true);
        thingy.LoadScene();
    }
}
