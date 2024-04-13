using UnityEngine;

public class Combat : MonoBehaviour {
    [SerializeField] private Animator _animator;

    public Animator Animator {
        get { return _animator; }
        set { _animator = value; }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Attack();
        }
    }

    private void Attack() {
        _animator.SetTrigger("Attack");
    }
}
