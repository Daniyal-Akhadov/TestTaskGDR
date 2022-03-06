using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private CircleCounter _counter;

    private void Awake()
    {
        _counter = FindObjectOfType<CircleCounter>();
    }

    private void OnEnable()
    {
        _counter.ScoreIncreased += OnScoreChanged;
    }

    private void OnDisable()
    {
        _counter.ScoreIncreased -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
}
