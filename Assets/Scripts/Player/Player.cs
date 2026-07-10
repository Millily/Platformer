using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(Rigidbody2D), typeof(Wallet))]
[RequireComponent(typeof(Jumper), typeof(PlayerMovement), typeof(GroundChecker))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerVisual _visualController;

    private InputReader _inputReader;
    private Rigidbody2D _rigidbody2D;
    private Jumper _jumper;
    private PlayerMovement _movement;
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _jumper = GetComponent<Jumper>();
        _movement = GetComponent<PlayerMovement>();
        _groundChecker = GetComponent<GroundChecker>();
    }

    private void OnEnable()
    {
        _inputReader.ButtonJumpPressed += OnJump;
    }

    private void OnDisable()
    {
        _inputReader.ButtonJumpPressed -= OnJump;
    }

    private void Update()
    {
        _visualController?.SetMovementState(_inputReader.Direction);
    }

    private void FixedUpdate()
    {
        _movement.Move(_inputReader.Direction, _rigidbody2D);
    }

    private void OnJump()
    {
        _jumper.Jump(_rigidbody2D, _groundChecker.IsGrounded);
    }
}