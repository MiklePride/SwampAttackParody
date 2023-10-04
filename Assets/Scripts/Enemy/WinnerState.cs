using UnityEngine;

[RequireComponent (typeof(Animator))]
public class WinnerState : State
{
    private Animator _animator;
    private int _winner = Animator.StringToHash("WinnerEnemy");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(_winner);
    }

    private void OnDisable()
    {
        _animator.StartPlayback();
    }
}
