using UnityEngine;
using UnityEngine.Events;

public class CircleCounter : MonoBehaviour
{
    private int _maxCount;
    private int _currentCount;

    public event UnityAction<int> ScoreIncreased;
    public event UnityAction AllCaught;

    private void Awake()
    {
        _maxCount = FindObjectsOfType<Circle>().Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Circle enemy))
        {
            _currentCount++;
            ScoreIncreased?.Invoke(_currentCount);

            if (_currentCount >= _maxCount)
                AllCaught?.Invoke();

            Destroy(enemy.gameObject);
        }
    }
}
