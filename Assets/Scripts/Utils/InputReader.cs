using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private GameInput _gameInput;

    private InputAction moveAction;
    private InputAction jumpAction;

    public event Action ButtonJumpPressed;

    public float Direction {  get; private set; }

    private void Awake()
    {
        _gameInput = new GameInput();
        moveAction = _gameInput.FindAction("Move");
        jumpAction = _gameInput.FindAction("Jump");
    }

    private void OnEnable()
    {
        _gameInput.Enable();
    }

    private void OnDisable()
    {
        _gameInput.Disable();
    }

    private void Update()
    {
        Direction = moveAction.ReadValue<float>();

        if (jumpAction.IsPressed())
        {
            ButtonJumpPressed?.Invoke();
        }
    }
}