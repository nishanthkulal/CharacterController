
namespace _CharacterController.Interfaces
{
    internal interface IPlayerJump
    {
        public void UpdatePlayerJumpPosition();
        public void ApplyJump();
        public bool CheckPlayerGrounded();
    }
}
