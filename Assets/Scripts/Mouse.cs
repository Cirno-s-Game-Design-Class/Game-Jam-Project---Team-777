using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject open;
    public GameObject closed;

    Vector2 screenPos;
    Vector2 worldMousePos;

    private void Update()
    {
        screenPos = Input.mousePosition;
        transform.position = worldMousePos = Camera.main.ScreenToWorldPoint(screenPos);

        if (Input.GetMouseButton(0))
        {
            open.SetActive(false);
            closed.SetActive(true);
            Grab();
        }
        else
        {
            open.SetActive(true);
            closed.SetActive(false);
        }
    }

    private void Grab()
    {
        RaycastHit2D hit = Physics2D.Raycast(worldMousePos, Vector2.zero);
        Vector2 hitpoint = hit.point;
        Vector2 localHitPoint = transform.InverseTransformPoint(hitpoint);
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        if (hit.collider != null)
        {
            Debug.Log(localHitPoint);
            hit.transform.position = new Vector2(worldMousePos.x - 0.54f, worldMousePos.y);
        }
    }
}
