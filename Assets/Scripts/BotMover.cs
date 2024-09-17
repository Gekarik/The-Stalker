using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private float _stepOffset = 1f;
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _stoppingDistance = 2f;
    [SerializeField] private float _rayDistance = 0.5f;

    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var distance = Vector3.Distance(_target.position, transform.position);

        if (distance > _stoppingDistance)
        {
            var direction = (_target.position - transform.position).normalized;
            var moveVelocity = direction * _moveSpeed;

            _rigidbody.velocity = moveVelocity;
        }
        else
        {
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
        }
    }
}
