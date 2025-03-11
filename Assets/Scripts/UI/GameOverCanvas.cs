using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
    public void RestartButton()
    {
        GameStateManager.Instance.RestartGame();
    }
    public void ExitButton()
    {
        GameStateManager.Instance.ExitGame();
    }
}