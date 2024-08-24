using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectingLevel : MonoBehaviour
{
    public GameObject description;

    private void Update()
    {
        description.SetActive(gameObject.GetComponent<Toggle>().isOn);
    }
}
