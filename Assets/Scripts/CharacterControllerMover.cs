using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController), typeof(InputReader))]
public class CharacterControllerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _shiftedSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private KeyCode _keyForBoostSpeed = KeyCode.LeftShift;
    [SerializeField] private float _smoothTime = 0.2f;

    private float _defaultSpeed;
    private float _currentSpeed;
    private float _speedVelocity;

    private Transform _transform;
    private InputReader _inputReader;
    private CharacterController _characterController;
    private AnimatorController _animatorController;

    private void Awake()
    {
        _defaultSpeed = _moveSpeed;
        _transform = transform;

        _inputReader = GetComponent<InputReader>();
        _characterController = GetComponent<CharacterController>();
        TryGetComponent(out _animatorController);
    }

    private void FixedUpdate()
    {
        if (_animatorController != null)
            _animatorController.UpdateSpeed(_characterController.velocity.magnitude);

        UpdateSpeed();
        Move();
        Rotate();
    }

    private void UpdateSpeed()
    {
        float targetSpeed = _inputReader.IsButtonDown(_keyForBoostSpeed) ? _shiftedSpeed : _defaultSpeed;
        _currentSpeed = Mathf.SmoothDamp(_currentSpeed, targetSpeed, ref _speedVelocity, _smoothTime);
    }

    private void Move()
    {
        Vector3 forward = _transform.forward;
        float curSpeed = _currentSpeed * _inputReader.Moving * Time.deltaTime;
        _characterController.Move(forward * curSpeed + Vector3.down);
    }

    private void Rotate()
    {
        float rotation = _inputReader.Rotation * _rotateSpeed;
        _transform.Rotate(0, rotation, 0);
    }
}
