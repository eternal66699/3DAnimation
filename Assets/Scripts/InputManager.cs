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
    public bool sprint_Input;
    public bool walk_Input;

    private void OnEnable()
    {
        if (playerControls == null) 
        {
            playerControls = new Player_Controls();
            playerControls.Player_Movement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.Player_Action.Sprint.performed += i => sprint_Input = true;
            playerControls.Player_Action.Sprint.canceled += i => sprint_Input = false;

            playerControls.Player_Action.Walk.performed += i => walk_Input = true;
            playerControls.Player_Action.Walk.canceled += i => walk_Input = false;
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
        HandleSprinting(); HandleWalking();

    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput)+ Mathf.Abs(verticalInput));
        PlayerManager.Instance.playerAnimation.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleSprinting()
    {
        if (sprint_Input && moveAmount > 0.5)
        {
            PlayerManager.Instance.isSprinting = true;
        }
        else
        {
            PlayerManager.Instance.isSprinting = false;
        }
    }

    private void HandleWalking()
    {
        if (walk_Input)
        {
            PlayerManager.Instance.isWalking = true;
        }
        else
        {
            PlayerManager.Instance.isWalking = false;
        }
    }
}
