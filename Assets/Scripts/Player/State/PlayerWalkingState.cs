using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveMentSystem
{
    public class PlayerWalkingState : PlayerMoveSystem
    {
        public PlayerWalkingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }
    }

}
