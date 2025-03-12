using UnityEngine;
namespace _CharacterController.CharacterState
{
    public class IdleState : CharacterBaseState
    {
        public override void Enter(StateManager player)
        {
            player.playerAnimation.HandleAnimation("Idle");
            Debug.Log("Idle");
        }

        public override void UpdateState(StateManager player)
        {
            if (player.inputHandler.movX != 0 || player.inputHandler.movZ != 0)
            {
                //Debug.Log("Run Update");
                player.SwitchState(player.runState);
            }
            if (player.playerJump.CheckPlayerGrounded() && player.inputHandler.jump)
            {
                player.SwitchState(player.jumpState);
            }

        }
    }
}
