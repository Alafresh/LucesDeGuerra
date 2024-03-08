using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootEmUp
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour {

        // Set the player input component to c# events
        private PlayerInput _playerInput;
        InputAction moveAction;
        InputAction fireAction;
        public Vector2 Move => moveAction.ReadValue<Vector2>();

        public bool Fire => fireAction.ReadValue<float>() > 0f;

        public void Start ()
        {
            _playerInput = GetComponent<PlayerInput>();
            moveAction = _playerInput.actions["Move"];
            fireAction = _playerInput.actions["Fire"];
        }
    }
}
