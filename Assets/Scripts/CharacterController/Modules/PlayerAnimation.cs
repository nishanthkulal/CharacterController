using _CharacterController.Interfaces;
using UnityEngine;
namespace _CharacterController.modules
{

    public class PlayerAnimation : MonoBehaviour, IPlayerAnimation
    {
        [SerializeField] private Animator playerAnimator;

        public void HandleAnimation(string statename)
        {
            playerAnimator.SetTrigger(statename);
        }
    }
}
