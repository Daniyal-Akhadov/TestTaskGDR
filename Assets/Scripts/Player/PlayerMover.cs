using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Vector2 _worldMousePosition;

    private void Update()
    {
        _worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        transform.position = _worldMousePosition;
    }
}
