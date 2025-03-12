using _CharacterController.Interfaces;
using UnityEngine;
namespace Charactercontroller.Modules
{
    public class PlayerRelativeMovement : MonoBehaviour, IPlayerMovement
    {
        [SerializeField] private CharacterController PlayerController;
        [SerializeField] private Transform playerCamera;
        [SerializeField] private float playerSpeed;
        private float turnSmoothVelocity;
        private float turnSmoothTime = 0.1f;

        public void Move(float movX, float movZ)
        {
            Vector3 direction = new Vector3(movX, 0.0f, movZ).normalized;
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                PlayerController.Move(moveDir.normalized * playerSpeed * Time.deltaTime);

            }
        }
    }

}
