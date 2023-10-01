using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Transform _transform;
    private GameObject _gameObejct;
    private Transform _lastParent;

    private Transform _direction;
    private float _currentDirection;
    private Coroutine _lifeTimeRoutine;
    private float _lifeTime = 5f;

    public Damage Damage { get; private set; }

    public void Init(Transform bulletPoint, Transform bulletDirection)
    {
        _transform = transform;
        _gameObejct = gameObject;
        _lastParent = bulletPoint;
        _direction = bulletDirection;

        Damage = new Damage(5);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IGetDamage getDamage))
        {
            getDamage.Health.ApplyDamage(Damage);
        }

        EndShoot();
    }

    private void OnEnable()
    {
        _lifeTimeRoutine = StartCoroutine(LifeTime());

        if (_lastParent != null)
        {
            _currentDirection = _direction.localScale.x;
        }
    }

    private void OnDisable()
    {
        if (_lifeTimeRoutine != null)
            StopCoroutine(_lifeTimeRoutine);
    }

    private void Update()
    {
        if (_transform != null)
            _transform.Translate(_transform.right * (_currentDirection) * 10 * Time.deltaTime);
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        EndShoot();
    }

    private void EndShoot()
    {
        _transform.SetParent(_lastParent);
        _transform.localPosition = Vector2.zero;
        _gameObejct.SetActive(false);
    }
}
