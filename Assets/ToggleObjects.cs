using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject[] objectsToToggle; // Assign the objects in the inspector

    // Method to hide all objects except the one to show
    public void ShowOnlyObject(int index)
    {
        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            if (objectsToToggle[i] != null)
                objectsToToggle[i].SetActive(i == index);
        }
    }
}
