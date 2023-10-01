using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour, IContainSpeed
{
    public Transform Transform { get; private set; }

    public MoveSpeed MoveSpeed;
    private Rigidbody2D _rigidbody2D;
    private IInput _input;

    private bool _isMoving = true;

    public System.Action<bool> OnMove;

    public void Init(IInput input)
    {
        _input = input;
        Transform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        MoveSpeed = new MoveSpeed();
    }

    public void SetPosition(Vector3 position) =>
        Transform.position = position;

    public void Enable()
    {
        if (_rigidbody2D != null)
        {
            _rigidbody2D.isKinematic = false;
        }

        _isMoving = true;
    }

    public void Disable()
    {
        _isMoving = false;

        if (_rigidbody2D != null)
        {
            _rigidbody2D.isKinematic = true;
        }

        OnMove?.Invoke(false);
    }

    public MoveSpeed GetMoveSpeed() => MoveSpeed;

    private void Update()
    {
        if (_input != null)
        {
            Move();

            if (_rigidbody2D.velocity != Vector2.zero)
                Rotate();
        }
    }

    private void Move()
    {
        if (_input.GetAxis() != Vector3.zero)
            OnMove?.Invoke(true);
        else    OnMove?.Invoke(false);

        if (_isMoving == false)
            return;

        Vector3 position2D = new Vector3(_input.GetAxis().x, _input.GetAxis().y, 0);

        Vector3 position = position2D * MoveSpeed.CurrentValue;
        _rigidbody2D.velocity = position;
    }

    private void Rotate()
    {
        if (_input.GetAxis().x < 0)
            Transform.localScale = new Vector3(-1, 1, 1);
        else
            Transform.localScale = Vector3.one;
    }
}
