using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    private readonly List<Vector3> _points = new();
    
    [SerializeField]
    private LineRenderer _lineRenderer;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            DrawLine();
        }
        else
        {
            ResetPreviousLine();   
        }
    }

    private void DrawLine()
    {
        var mousePosition = Input.mousePosition;
        var ray = _camera.ScreenPointToRay(mousePosition);

        if (!Physics.Raycast(ray, out var hitInfo)) return;

        var point = hitInfo.point;
        _points.Add(point);
        var points = _points.ToArray();
        _lineRenderer.positionCount = points.Length;
        _lineRenderer.SetPositions(points);
    }
    
    private void ResetPreviousLine()
    {
        _points.Clear();
    }
}
