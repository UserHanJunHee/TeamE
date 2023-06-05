using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MoveMentSystem
{
    public class PlayerMoveSystem : IState
    {
        protected PlayerMovementStateMachine stateMachine;

        protected Vector2 movementInput;

        protected float baseSpeed = 5.0f;
        protected float speedModifier = 1.0f;
        public PlayerMoveSystem(PlayerMovementStateMachine playerMovementStateMachine)
        {
            stateMachine = playerMovementStateMachine;
        }

        #region 스테이트 관련

        public virtual void Enter()
        {
           
        }

        public virtual void Exit()
        {
           
        }

        public virtual void HandleInput()
        {
            ReadMovementInput();
        }

        public virtual void PhysicsUpdate()
        {
           
        }

        public virtual void Update()
        {
            Move();
        }
        #endregion


        #region 플레이어 무브 시스템 함수
        private void ReadMovementInput()
        {
            movementInput = stateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
        }

        private void Move()
        {
            if(movementInput == Vector2.zero || speedModifier == 0f)
            {
                return;
            }

            Vector3 movementDirection = GetMovementInputDirection();

            float movementSpeed = GetMovementSpeed();

            Vector3 currentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();

            stateMachine.Player.Rigidbody.AddForce(movementSpeed * 5f * movementDirection - currentPlayerHorizontalVelocity, ForceMode.VelocityChange);
        }

        
        private Vector3 GetMovementInputDirection()
        {
            return new Vector3(movementInput.x, 0f, movementInput.y);
        }
        protected float GetMovementSpeed()
        {
            return baseSpeed * speedModifier;
        }

        protected Vector3 GetPlayerHorizontalVelocity()
        {
            Vector3 playerHorizontalVelocity = stateMachine.Player.Rigidbody.velocity;

            playerHorizontalVelocity.y = 0f;

            return playerHorizontalVelocity;
        }


        #endregion
    }
}


