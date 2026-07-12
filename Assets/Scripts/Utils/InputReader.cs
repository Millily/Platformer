using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private GameInput _gameInput;

    public event Action ButtonJumpPressed;

    public float Direction {  get; private set; }

    private void Awake()
    {
        _gameInput = new GameInput();
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
        Direction = _gameInput.Gameplay.Move.ReadValue<float>();

        if (_gameInput.Gameplay.Jump.IsPressed())
        {
            ButtonJumpPressed?.Invoke();
        }
    }
}