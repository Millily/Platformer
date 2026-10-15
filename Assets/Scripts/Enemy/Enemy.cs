using UnityEngine;

[RequireComponent(typeof(Patroller), typeof(EnemyStateMachineFactory), typeof(Health))]
[RequireComponent(typeof(Mover), typeof(Chaser), typeof(EnemyVision))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private EnemyVisual _enemyVisual;
    [SerializeField] private float _speed = 5f;

    private StateMachine _stateMachine;
    private Mover _mover;

    public Health Health { get; private set; }
    public Patroller Patroller { get; private set; }
    public Attacker Attacker { get; private set; }
    public EnemyVision EnemyVision { get; private set; }
    public EnemyVisual EnemyVisual { get; private set; }
    public Chaser Chaser { get; private set; }
    public float CooldownDuration { get; private set; } = 2f;


    private void Awake()
    {
        _mover = GetComponent<Mover>();
        Patroller = GetComponent<Patroller>();
        Health = GetComponent<Health>();
        Chaser = GetComponent<Chaser>();
        EnemyVision = GetComponent<EnemyVision>();

        Attacker = _attacker;
        EnemyVisual = _enemyVisual;
    }

    private void Start()
    {
        _stateMachine = GetComponent<EnemyStateMachineFactory>().Create(this);
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    public void OnAttack()
    {
        Attacker.TryAttack();
        EnemyVisual.SetAttackState();
    }

    public void OnPatroll()
    {
        Patroller.Patroll(_mover, _speed);
    }

    public void OnChase()
    {
        Chaser.Chase(_mover, EnemyVision, _speed);
    }
}