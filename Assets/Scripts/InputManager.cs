using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Player_Controls playerControls;
    private Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    public float moveAmount;

    private void OnEnable()
    {
        if (playerControls == null) 
        {
            playerControls = new Player_Controls();
            playerControls.Player_Movement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput)+ Mathf.Abs(verticalInput));
        PlayerManager.Instance.playerAnimation.UpdateAnimatorValues(0, moveAmount);
    }
}
