using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    PlayerInputAction inputActions;
    AnimatorManager animatorManager;


    public Vector2 movementInput;
    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
    }

    private void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new PlayerInputAction();

            inputActions.Player.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            inputActions.Player.Movement.canceled += i => movementInput = Vector2.zero;
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
        //점프
        //핸들액션인풋

    }

    private void HandleMoveInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }
}
