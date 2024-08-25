using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeMergeGame : MonoBehaviour
{
    public Button[] emptySquares; // Buttons for empty squares
    public Button[] shapeButtons; // Buttons for selecting shapes
    public Sprite[] mergedShapes; // Sprites that represent the correct merged shapes
    public GameObject resultDisplay; // Area to display the result sprite

    private int selectedShapeCount = 0;
    private const int MaxShapes = 4; // Maximum shapes to select, for special case
    private List<int> selectedShapes = new List<int>(); // To keep track of selected shapes

    void Start()
    {
        foreach (var square in emptySquares)
        {
            square.onClick.AddListener(() => SelectSquare(square));
        }

        foreach (var shape in shapeButtons)
        {
            shape.onClick.AddListener(() => SelectShape(shape));
        }
    }

    void SelectSquare(Button square)
    {
        ResetSelections(); // Reset selections when a new square is selected
        resultDisplay.SetActive(false); // Hide the result display initially
    }

    void SelectShape(Button shape)
    {
        if (selectedShapes.Count < MaxShapes && !selectedShapes.Contains(shape.transform.GetSiblingIndex()))
        {
            selectedShapes.Add(shape.transform.GetSiblingIndex());
            shape.interactable = false; // Visually indicate that the shape is selected
            selectedShapeCount++;

            if (selectedShapeCount >= 2) // Minimum shapes to select
            {
                CheckShapeCombination();
            }
        }
    }

    void CheckShapeCombination()
    {
        // Dummy check for correct combination (replace with actual logic)
        if (selectedShapes.Contains(0) && selectedShapes.Contains(1)) // Example check
        {
            resultDisplay.SetActive(true); // Show the merged result
            resultDisplay.GetComponent<Image>().sprite = mergedShapes[0]; // Assume 0 index for correct merge
        }
        else
        {
            ResetSelections(); // Reset if the combination is wrong
        }
    }

    void ResetSelections()
    {
        foreach (var index in selectedShapes)
        {
            shapeButtons[index].interactable = true; // Re-enable the button
        }
        selectedShapes.Clear();
        selectedShapeCount = 0;
    }
}
