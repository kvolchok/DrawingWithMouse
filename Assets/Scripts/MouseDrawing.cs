using UnityEngine;

public class MouseDrawing : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ResetPreviousDrawing();
        }
        
        if (Input.GetMouseButton(0))
        {
            Draw();
        }
    }

    private void Draw()
    {
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        var point = _camera.ScreenToWorldPoint(mousePosition);

        var index = ++_lineRenderer.positionCount - 1;
        _lineRenderer.SetPosition(index, point);
    }

    private void ResetPreviousDrawing()
    {
        _lineRenderer.positionCount = 0;
    }
}