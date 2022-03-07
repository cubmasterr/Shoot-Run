using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class CharacterController : MonoBehaviour, IMovable,IAchievable
{
    [SerializeField] private Gun _gunPrefab;
    [SerializeField] private Transform _weaponPoint;
    [SerializeField] private float _rotateDuration;
    private NavMeshAgent _agent;
    private Animator _animator;
    private Gun _gun;
    public void SetAchievable(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }

    public void SetMovementCondition(MovementConditionEnum movementCondition, bool isStoped)
    {
        _agent.isStopped = isStoped;
        _animator.SetInteger("MovementCondition", (int)movementCondition);
        if (isStoped)
        {
            GameStateManager.Instance.CharacterStoped();
            _gun.enabled = true;
        }
        else 
        {
            GameStateManager.Instance.CharacterRunning(transform);
            _gun.enabled = false;
        }
    }

    public void RotateCharacter(Vector3 destination)
    {
        var rotation = Quaternion.LookRotation(destination);
        var sequince = DOTween.Sequence();
        sequince.Append(transform.DORotate(rotation.eulerAngles, _rotateDuration));
    }

    private void Awake()
    {
        GameStateManager.Instance.OnMatchStarted += OnMatchStarted;
        GameStateManager.Instance.OnRestartMatch += DestroyCharacter;
        GameStateManager.Instance.OnRandomLevel += DestroyCharacter;
        GameStateManager.Instance.CharacterRunning(transform);
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        InstanceWeapon();
    }

    private void InstanceWeapon()
    {
        _gun = Instantiate(_gunPrefab, _weaponPoint.position, _weaponPoint.rotation);
        _gun.transform.SetParent(_weaponPoint);
        _gun.OnCalculateDestination += RotateCharacter;
    }

    private void OnMatchStarted()
    {
        SetMovementCondition(MovementConditionEnum.Run, false);
        GameStateManager.Instance.OnMatchStarted -= OnMatchStarted;
    }
    private void DestroyCharacter()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        _gun.OnCalculateDestination -= RotateCharacter;
        GameStateManager.Instance.OnRestartMatch -= DestroyCharacter;
        GameStateManager.Instance.OnRandomLevel -= DestroyCharacter;
    }
}