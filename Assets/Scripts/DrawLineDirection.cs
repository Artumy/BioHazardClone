using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLineDirection : MonoBehaviour
{
    private LineRenderer _line;

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
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));

        _line.enabled = true;

    }

    public void DrawLine()
    {
        _line.SetPosition(1, Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
    }

    public void EndDrawLine()
    {
        _line.enabled = false;
    }

}
