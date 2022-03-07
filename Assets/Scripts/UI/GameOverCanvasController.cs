using UnityEngine;

public class GameOverCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _restartCanvas;

    private void Start()
    {
        GameStateManager.Instance.OnMatchFinished += OnLineFinished;
    }

    private void OnLineFinished()
    {
        _restartCanvas.SetActive(true);
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnMatchFinished -= OnLineFinished;
    }
}