using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLineDirection : MonoBehaviour
{
    private LineRenderer _line;

    private float _cameraPositionZ = 10;
    private int _endPoint = 1;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.enabled = false;
        _line.positionCount = 2;
    }

    public void SetStartPositionLine()
    {
        for (int i = 0; i < _line.positionCount; i++)
            _line.SetPosition(i, Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cameraPositionZ)));

        _line.enabled = true;
    }

    public void DrawLine()
    {
        _line.SetPosition(_endPoint, Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cameraPositionZ)));
    }

    public void EndDrawLine()
    {
        _line.enabled = false;
    }

}
