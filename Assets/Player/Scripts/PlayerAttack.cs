using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    [SerializeField] private Transform _attackTransform;
    [SerializeField] private float _attackRange = 1.0f;
    [SerializeField] private LayerMask _attackableLayer;
    [SerializeField] private float _amoundDamage = 1.0f;
    [SerializeField] private float _timeBetweenAttacks = 0.15f;

    private RaycastHit2D[] _hits;
    private Animator _animator;
    private float _attackTimeCounter;

    public bool ShouldBeDamaging { get; private set; } = false;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    private void Start() {
        _attackTimeCounter = _timeBetweenAttacks;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _attackTimeCounter >= _timeBetweenAttacks) {
            _attackTimeCounter = 0.0f;

            _animator.SetTrigger("Attack");
        }

        _attackTimeCounter += Time.deltaTime;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(_attackTransform.position, _attackRange);
    }

    public IEnumerator DamageWhileSlashIsActive() {
        ShouldBeDamaging = true;

        while (ShouldBeDamaging) {
            _hits = Physics2D.CircleCastAll(_attackTransform.position, _attackRange, transform.right, 0.0f, _attackableLayer);

            for (int i = 0; i < _hits.Length; ++i) {
                IDamageable iDamageable = _hits[i].collider.gameObject.GetComponent<IDamageable>();

                iDamageable?.Damage(_amoundDamage);
            }

            yield return null;
        }
    }

    #region Animation Triggers

    public void ShouldBeDamagingToTrue() {
        ShouldBeDamaging = true;
    }

    public void ShouldBeDamagingToFalse() {
        ShouldBeDamaging = false;
    }

    #endregion
}
