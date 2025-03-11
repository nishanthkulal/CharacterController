using System;
using _CharacterController.Interfaces;
using UnityEngine;
namespace _CharacterController.modules
{

    public class PlayerMovement : MonoBehaviour, IPlayerMovement
    {
        [SerializeField] private CharacterController playerController;
        [SerializeField] private float playerSpeed = 2.0f;

        public void Move(float movX, float movZ)
        {
            //Debug.Log("Move");
            Vector3 movement = new Vector3(movX, 0.0f, movZ);
            playerController.Move(movement * Time.deltaTime * playerSpeed);
        }

    }
}
