using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    private PlayerActions _playerActions;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerActions = new();
    }

    private void OnEnable()
    {
        _playerActions.Enable();
    }

    private void Start()
    {
        _playerActions.Combat.Attack.started += _ => Attack();
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
