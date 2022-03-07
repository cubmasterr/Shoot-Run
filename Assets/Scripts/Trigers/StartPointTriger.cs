using UnityEngine;

public class StartPointTriger : MonoBehaviour
{
    [SerializeField] private CharacterController _characterPrefab;
    [SerializeField] private Transform _characterSpawnTransform;
    [SerializeField] private Transform _nextWayPoint;
    private IAchievable _iAchievable;

    private void OnEnable()
    {
        _iAchievable = Instantiate(_characterPrefab, _characterSpawnTransform.position, _characterSpawnTransform.rotation);
        InputManager.Instance.OnClic += StartMatch;
    }   

    private void StartMatch()   
    {
        _iAchievable.SetAchievable(_nextWayPoint.position);
        GameStateManager.Instance.MatchStarted();
        InputManager.Instance.OnClic -= StartMatch;
    }
}
