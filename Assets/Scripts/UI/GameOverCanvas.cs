using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    public void RandomLevelButton()
    {
        GameStateManager.Instance.RandomLevel();
        gameObject.SetActive(false);
    }

    public void RestarButton()
    { 
       GameStateManager.Instance.RestartMatch();
       gameObject.SetActive(false);
    }
}