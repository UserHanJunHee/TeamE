using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveMentSystem
{
    public class PlayerIdlingState : PlayerMoveSystem
    {
        public PlayerIdlingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }
    }

}
