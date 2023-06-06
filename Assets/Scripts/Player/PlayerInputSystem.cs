using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    PlayerInputAction inputActions;
    Rigidbody playerRigidbody;

    public Vector2 movementInput;
    public Vector3 moveDir;
    public float movementSpeed = 5.0f;


    private void Awake()
    {
        inputActions = new PlayerInputAction();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Movement.performed += MovementLogic;
        inputActions.Player.Movement.canceled += MovementLogic;
    }

    private void MovementLogic(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        moveDir.x = movementInput.x;
        moveDir.z = movementInput.y;
    }


    private void OnDisable()
    {
        inputActions.Player.Disable();
    }


    private void FixedUpdate()
    {
        playerRigidbody.MovePosition(gameObject.transform.position + moveDir * movementSpeed * Time.fixedDeltaTime);
    }


}
