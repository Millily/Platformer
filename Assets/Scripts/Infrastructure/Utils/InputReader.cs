using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private GameInput _gameInput;

    public event Action ButtonJumpPressed;
    public event Action ButtonAttackPressed;
    public float Direction {  get; private set; }

    private void Awake()
    {
        _gameInput = new GameInput();
    }

    private void OnEnable()
    {
        _gameInput.Enable();

        _gameInput.Gameplay.Jump.started += OnJumpStarted;
        _gameInput.Gameplay.Attack.started += OnAttackStarted;
    }

    private void OnDisable()
    {
        _gameInput.Disable();

        _gameInput.Gameplay.Jump.started -= OnJumpStarted;
        _gameInput.Gameplay.Attack.started -= OnAttackStarted;
    }

    private void Update()
    {
        Direction = _gameInput.Gameplay.Move.ReadValue<float>();
    }

    private void OnJumpStarted(InputAction.CallbackContext context)
    {
        ButtonJumpPressed?.Invoke();
    }

    private void OnAttackStarted(InputAction.CallbackContext context)
    {
        ButtonAttackPressed?.Invoke();
    }
}