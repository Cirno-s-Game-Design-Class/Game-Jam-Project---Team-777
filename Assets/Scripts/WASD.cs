using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class WASD : MonoBehaviour
{
    #region Variables
    public static WASDInput input = null;

    Vector2 movement;
    public float moveMult;

    Rigidbody2D rb;
    #endregion

    #region Initialize
    private void Awake()
    {
        input = new WASDInput();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovement;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovement;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    #endregion

    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (Input.anyKey)
            rb.velocity = Vector2.Lerp(rb.velocity, movement * moveMult, 0.2f);
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 0.2f);
            movement = Vector2.zero;
        }
    }
}
