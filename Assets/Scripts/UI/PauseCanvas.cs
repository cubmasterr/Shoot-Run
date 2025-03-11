using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCanvas : MonoBehaviour
{
    public void ContinueButton()
    {
        GameStateManager.Instance.ContinueGame();
    }
    public void RestartButton()
    {
        GameStateManager.Instance.RestartGame();
    }
    public void ExitButton()
    {
        GameStateManager.Instance.ExitGame();
    }
}