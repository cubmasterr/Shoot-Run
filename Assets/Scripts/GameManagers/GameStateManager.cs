using System;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    public Action OnMatchFinished;
    public Action OnCharacterStoped;
    public Action OnMatchStarted;
    public Action OnRestartMatch;
    public Action OnRandomLevel;
    public Action <Transform> OnCharacterCreated;

    public void LineFinished()
    {
        OnMatchFinished?.Invoke();
    }

    public void CharacterStoped()
    {
        OnCharacterStoped?.Invoke();
    }

    public void RestartMatch()
    {
        OnRestartMatch?.Invoke();
    }   

    public void RandomLevel()
    {
        OnRandomLevel?.Invoke();
    }

    public void MatchStarted()
    {
        OnMatchStarted?.Invoke();
    }

    public void CharacterRunning(Transform characterTransform)
    {
        OnCharacterCreated?.Invoke(characterTransform);
    }
}