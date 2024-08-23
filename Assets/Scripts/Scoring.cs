using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public static bool callScore;
    public static int score = 0;

    private void Update()
    {
        
    }

    public void Review()
    {
        callScore = true;
    }
}
