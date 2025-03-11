using UnityEngine;
namespace _CharacterController.CharacterState
{
    public class RunState : CharacterBaseState
    {
        public override void Enter(StateManager player)
        {
            Debug.Log("Run State");
        }

        public override void UpdateState(StateManager player)
        {
            if (player.inputHandler.movX == 0 && player.inputHandler.movZ == 0)
            {
                player.SwitchState(player.idleState);
            }
            if (player.playerJump.CheckPlayerGrounded() && player.inputHandler.jump)
            {
                player.SwitchState(player.jumpState);
            }
            player.playerMovement.Move(player.inputHandler.movX, player.inputHandler.movZ);
        }
    }

}
