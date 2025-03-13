using UnityEngine;
namespace _CharacterController.CharacterState
{
    public class JumpState : CharacterBaseState
    {
        public override void Enter(StateManager player)
        {
            player.playerAnimation.HandleAnimation("Jump");
            Debug.Log("Jump State");
            player.playerJump.ApplyJump();
        }

        public override void UpdateState(StateManager player)
        {
            if (player.playerJump.CheckPlayerGrounded())
            {
                player.SwitchState(player.idleState);
            }
            else if (player.inputHandler.movX != 0 || player.inputHandler.movZ != 0)
            {
                player.SwitchState(player.runAndJumpState);
            }

        }
    }
}
