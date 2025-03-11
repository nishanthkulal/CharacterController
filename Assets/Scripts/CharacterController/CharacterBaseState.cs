using Unity.VisualScripting;
using UnityEngine;
namespace _CharacterController
{
    public abstract class CharacterBaseState
    {
        public abstract void Enter(StateManager player);
        public abstract void UpdateState(StateManager player);
    }
}
