using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(Rigidbody2D))]
[RequireComponent(typeof(Jumper), typeof(PlayerMovement))]
[RequireComponent(typeof(Flipper), typeof(Collector))]
[RequireComponent(typeof(Health), typeof(Inventory))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerVisual _visualController;
    [SerializeField] private Attacker _attacker;

    private InputReader _inputReader;
    private Rigidbody2D _rigidbody2D;

    private Collector _collector;
    private Inventory _inventory;

    private Jumper _jumper;
    private PlayerMovement _movement;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        
        _inputReader = GetComponent<InputReader>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _jumper = GetComponent<Jumper>();
        _collector = GetComponent<Collector>();
        _inventory = GetComponent<Inventory>();

        _movement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _inputReader.ButtonJumpPressed += OnJump;
        _inputReader.ButtonAttackPressed += OnAttack;

        _collector.MedicinePicked += _health.TakeMedicine;
        _collector.CoinPicked += _inventory.AddCoin;
    }

    private void OnDisable()
    {
        _inputReader.ButtonJumpPressed -= OnJump;
        _inputReader.ButtonAttackPressed -= OnAttack;

        _collector.MedicinePicked -= _health.TakeMedicine;
        _collector.CoinPicked -= _inventory.AddCoin;
    }

    private void Update()
    {
        _visualController.SetMovementState(_inputReader.Direction);
    }

    private void FixedUpdate()
    {
        _movement.Move(_inputReader.Direction, _rigidbody2D);
    }

    private void OnAttack()
    {
        _attacker.TryAttack();
        _visualController.SetAttackState();
    }

    private void OnJump()
    {
        _jumper.Jump(_rigidbody2D);
    }
}