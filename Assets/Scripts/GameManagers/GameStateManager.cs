using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : Singleton<GameStateManager>
{
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private string _menuSceneName;
    private int enemyCount;
    private void Awake()
    {
        SetPause(false);
    }
    public void AddEnemy()
    {
        enemyCount++;
    }
    public void SubtractEnemy()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            SetPause(true);
            _gameOverCanvas.SetActive(true);
        }
    }
    public void GameOver()
    {
        SetPause(true);
        _gameOverCanvas.SetActive(true);
    }
    public void ContinueGame()
    {
        SetPause(false);
        _pauseCanvas.SetActive(false);
    }
    public void RestartGame()
    {
        SetPause(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& _gameOverCanvas.activeInHierarchy ==false)
        {
            _pauseCanvas.SetActive(!_pauseCanvas.activeInHierarchy);
            SetPause(_pauseCanvas.activeInHierarchy);
        }
    }
    private void SetPause(bool isPause)
    {
        Cursor.lockState = isPause ? CursorLockMode.Confined : CursorLockMode.Locked;
        Time.timeScale = isPause ? 0f : 1f ;
    }
}