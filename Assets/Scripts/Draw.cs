using UnityEngine;

public class Draw : MonoBehaviour
{
    private LineRenderer _line;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _line = GetComponent<LineRenderer>();
 
            _line.startColor = Color.red;
            _line.endColor = Color.blue;
            _line.startWidth = 0.1f;
            _line.endWidth = 0.1f;
        }
        if (Input.GetMouseButton(0))
        {
            _line.positionCount = 2;

            _line.SetPosition(1, Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)));
        }
    }
}