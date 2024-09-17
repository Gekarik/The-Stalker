using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void UpdateSpeed(float value)
    {
        _animator.SetFloat(AnimatorParams.Speed, value);
    }
}

public class AnimatorParams
{
    public const string Speed = nameof(Speed);
}