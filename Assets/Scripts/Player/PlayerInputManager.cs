using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    PlayerInputAction inputActions;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool b_Input;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new PlayerInputAction();

            inputActions.Player.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            inputActions.Player.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();


            inputActions.Player.Movement.canceled += i => movementInput = Vector2.zero;
            //inputActions.Player.Camera.canceled += i => movementInput = Vector2.zero;

            inputActions.PlayerAction.Sprint.performed += i => b_Input = true;
            inputActions.PlayerAction.Sprint.canceled += i => b_Input = false;
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMoveInput();
        HandleSprintingInput();
        //점프
        //핸들액션인풋
    }

    private void HandleMoveInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if(b_Input && moveAmount > 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }
}
