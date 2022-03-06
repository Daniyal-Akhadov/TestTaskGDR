using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private CanvasGroup _canvasGroup;

    private CircleCounter _counter;

    private void Awake()
    {
        _counter = FindObjectOfType<CircleCounter>();
        TurnOffScreen();
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartLevel);
        _counter.AllCaught += OnAllCaught;
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartLevel);
        _counter.AllCaught -= OnAllCaught;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UnpauseGame();
    }

    private void OnAllCaught()
    {
        TurnOnScreen();
        PauseGame();
    }

    private void TurnOffScreen()
    {
        const float MinAplha = 0;
        _canvasGroup.alpha = MinAplha;
    }

    private void TurnOnScreen()
    {
        const int MaxAlpha = 1;
        _canvasGroup.alpha = MaxAlpha;
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1f;
    }
}
