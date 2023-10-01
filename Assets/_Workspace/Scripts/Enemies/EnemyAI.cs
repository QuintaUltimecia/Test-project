using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyAnimationController))]
[RequireComponent(typeof(Movement))]
public class EnemyAI : MonoBehaviour, IInput
{
    public Movement Movement { get; private set; }
    public Damage Damage { get; private set; }
    public EnemyAnimationController AnimationController { get; private set; }

    private Transform _transform;

    private Player _player;
    private float _distanceToPlayer = 2f;
    private float _attackDuration = 1f;

    private Coroutine _attackRoutine;

    public void Disable()
    {

    }

    public void Enable()
    {

    }

    public Vector3 GetAxis()
    {
        if (_player != null)
        {
            if (Vector2.Distance(_transform.position, _player.transform.position) > _distanceToPlayer)
            {
                if (_attackRoutine == null)
                    return (_player.transform.position - _transform.position).normalized;
                else { return Vector3.zero; }
            }
            else
            {
                if (_attackRoutine == null)
                {
                    _attackRoutine = StartCoroutine(Attack());
                }

                return Vector3.zero;
            }
        }
        else { return Vector3.zero; }
    }

    public void Init()
    {
        Movement = GetComponent<Movement>();
        Movement.Init(this);
        Movement.MoveSpeed.SetValue(3f);
        Damage = new Damage(5);
        AnimationController = GetComponent<EnemyAnimationController>();
        AnimationController.Init();

        Movement.OnMove += (value) => AnimationController.Move(value);

        _transform = transform;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _player = player;
            _player.OnDeath += () => { _player = null; };
        }
    }

    private IEnumerator Attack()
    {
        _player.Health.ApplyDamage(Damage);
        AnimationController.Attack(true);
        yield return new WaitForSeconds(_attackDuration);
        AnimationController.Attack(false);
        _attackRoutine = null;
    }
}
