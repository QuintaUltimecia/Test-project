using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform _transform;
    private Transform _target;

    public void Init(Player player)
    {
        _transform = transform;
        _target = player.transform;
    }

    private void LateUpdate()
    {
        if (_target != null)
        {
            _transform.position = new Vector3(
                x: _target.position.x,
                y: _target.position.y,
                z: _transform.position.z);
        }
    }
}
