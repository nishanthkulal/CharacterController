using UnityEngine;
using _CharacterController.Interfaces;
namespace _CharacterController.modules
{

    public class PlayerInputHandler : MonoBehaviour, IPlayerInput
    {
        public float movX { get; private set; }
        public float movZ { get; private set; }
        public bool jump { get; private set; }

        public void ReadInput()
        {
            movX = Input.GetAxis("Horizontal");
            movZ = Input.GetAxis("Vertical");
            jump = Input.GetButtonDown("Jump");
        }
    }
}
