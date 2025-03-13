using UnityEngine;
namespace _CharacterController.CharacterState
{
    public class RunAndJump : CharacterBaseState
    {
        public override void Enter(StateManager player)
        {
            player.playerAnimation.HandleAnimation("ForwordJump");
            Debug.Log("Run and Jump State");
            player.playerJump.ApplyJump();
        }

        public override void UpdateState(StateManager player)
        {
            if (player.inputHandler.movX == 0 && player.inputHandler.movZ == 0)
            {
                player.SwitchState(player.idleState);
            }
            if (player.playerJump.CheckPlayerGrounded() && (player.inputHandler.movX != 0 || player.inputHandler.movZ != 0))
            {
                player.SwitchState(player.runState);
            }
            player.playerMovement.Move(player.inputHandler.movX, player.inputHandler.movZ);
        }
    }
}
