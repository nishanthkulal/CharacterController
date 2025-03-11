using _CharacterController.Interfaces;
using UnityEngine;
namespace _CharacterController.modules
{
    public class PlayerJump : MonoBehaviour, IPlayerJump
    {
        [SerializeField] private float jumpHeight = 1.0f;
        private CharacterController playerController;
        private Vector3 playerVelocity;
        private float gravityValue = -9.81f;
        void Awake()
        {
            playerController = GetComponent<CharacterController>();
        }
        public void UpdatePlayerJumpPosition()
        {
            if (CheckPlayerGrounded() && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            playerVelocity.y += gravityValue * Time.deltaTime;
            playerController.Move(playerVelocity * Time.deltaTime);

        }

        public void ApplyJump()
        {
            if (CheckPlayerGrounded())
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            }
        }
        public bool CheckPlayerGrounded() => playerController.isGrounded;
    }
}
