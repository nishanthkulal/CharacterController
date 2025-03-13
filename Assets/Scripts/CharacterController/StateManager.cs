using _CharacterController.CharacterState;
using _CharacterController.Interfaces;
using _CharacterController.modules;
using UnityEngine;
namespace _CharacterController
{
    public class StateManager : MonoBehaviour
    {
        CharacterBaseState currentState;
        internal IPlayerInput inputHandler;
        internal IPlayerMovement playerMovement;
        internal IPlayerJump playerJump;
        internal IPlayerAnimation playerAnimation;
        internal IdleState idleState = new IdleState();
        internal RunState runState = new RunState();
        internal JumpState jumpState = new JumpState();
        internal RunAndJump runAndJumpState = new RunAndJump();

        void Awake()
        {
            inputHandler = GetComponent<IPlayerInput>();
            playerMovement = GetComponent<IPlayerMovement>();
            playerJump = GetComponent<IPlayerJump>();
            playerAnimation = GetComponent<IPlayerAnimation>();
        }
        void Start()
        {
            currentState = idleState;
            idleState.Enter(this);
        }

        void Update()
        {
            inputHandler.ReadInput();
            playerJump.UpdatePlayerJumpPosition();
            currentState.UpdateState(this);
        }
        public void SwitchState(CharacterBaseState state)
        {
            if (currentState == state) return;
            currentState = state;
            state.Enter(this);
        }
    }
}
