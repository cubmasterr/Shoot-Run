using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Transform> _levels;
    private GameObject _currentLevel;

    private void Start()
    {
        RandomLevel();
        GameStateManager.Instance.OnRandomLevel += RandomLevel;
        GameStateManager.Instance.OnRestartMatch += RestartLevel;
        GameStateManager.Instance.OnMatchFinished += OnMatchFinished;
    }

    private void OnMatchFinished() 
    {
        _currentLevel.SetActive(false);
    }

    private void RestartLevel()
    {
        _currentLevel.SetActive(true);
    }

    private void RandomLevel()
    {
        _currentLevel = _levels[Random.Range(0, _levels.Count)].gameObject;
        _currentLevel.SetActive(true);
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnRandomLevel -= RandomLevel;
        GameStateManager.Instance.OnRestartMatch -= RestartLevel;
        GameStateManager.Instance.OnMatchFinished -= OnMatchFinished;
    }
}