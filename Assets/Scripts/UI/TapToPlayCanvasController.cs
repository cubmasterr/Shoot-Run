using UnityEngine;

public class TapToPlayCanvasController : MonoBehaviour
{
    private void Start()
    {
        GameStateManager.Instance.OnMatchStarted += OnMatchStarted;
        GameStateManager.Instance.OnMatchFinished += OnLineFinished;
    }

    private void OnLineFinished()
    {
        gameObject.SetActive(true);
    }

    private void OnMatchStarted()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnMatchStarted -= OnMatchStarted;
        GameStateManager.Instance.OnMatchFinished -= OnLineFinished;
    }
}