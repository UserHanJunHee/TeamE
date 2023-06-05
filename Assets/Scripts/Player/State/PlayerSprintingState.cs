using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveMentSystem
{
    public class PlayerSprintingState : PlayerMoveSystem
    {
        public PlayerSprintingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }
    }
}
