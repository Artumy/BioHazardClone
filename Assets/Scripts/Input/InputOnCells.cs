using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOnCells : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private LineRenderer _line;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _line = GetComponent<LineRenderer>();
        _line.enabled = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("Down");
        _line.enabled = true;

        _line.startColor = Color.red;
        _line.endColor = Color.blue;
        _line.startWidth = 0.1f;
        _line.endWidth = 0.1f;

        _line.SetPosition(0, Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
    }

    private void OnMouseEnter()
    {
        Debug.Log("Enter");
        _spriteRenderer.enabled = false;
    }

    private void OnMouseExit()
    {
        _spriteRenderer.enabled = true;
    }

    private void OnMouseUp()
    {
        Debug.Log("Up");
        _line.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _line.positionCount = 2;

            _line.SetPosition(1, Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
        }
    }
}
