using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animator))]
public class EnemyInfantry : Enemy
{
    [SerializeField] private Rigidbody[] _rigidbodies;


    private Animator _animator;
    private NavMeshAgent navMeshAgent;
    protected override void Start()
    {
        base.Start();
        _animator = gameObject.GetComponent<Animator>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }
    protected override void Death()
    {       

        _animator.enabled = false;
        navMeshAgent.isStopped=true;
        foreach (Rigidbody rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
        } 
        base.Death();
    }
    private void Update()
    {
        if (_target != null && _isDeath == false)
        {
            _animator.SetBool("ChasePlayer", true);
            navMeshAgent.destination = _target.position;
        }
        else
        {
            navMeshAgent.destination = transform.position;
            _animator.SetBool("ChasePlayer", true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_isDeath)
        {
            return;
        }
        var player = collision.gameObject.GetComponent<HealthController>();
        if (player != null) 
        {
            player.TakeDamage(_damage);
            Instantiate(_explosionEffect);
            _timeToDestroy = 0;
            Death();
        }

    }
}
