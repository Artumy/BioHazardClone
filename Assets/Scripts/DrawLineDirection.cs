using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLineDirection : MonoBehaviour
{
    private LineRenderer _line;
    private float _cameraPositionZ = 10;

    private float _parentPositionX;
    private float _parentPositionY;

    public LineRenderer Line => _line;

    private void Awake()
    {
        _parentPositionX = transform.parent.position.x;
        _parentPositionY = transform.parent.position.y;
    }
    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.enabled = false;
        _line.positionCount = 2;
        _line.SetPosition(0, new Vector3(_parentPositionX, _parentPositionY, _cameraPositionZ));
        _line.SetPosition(1, new Vector3(_parentPositionX, _parentPositionY, _cameraPositionZ));
    }

    public void SetStartPositionLine()
    {
        _line.enabled = true;
        _line.SetPosition(0, new Vector3(_parentPositionX, _parentPositionY, _cameraPositionZ));
    }

    public void DrawLine()
    {
        _line.SetPosition(1, Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cameraPositionZ)));
    }

    public void EndDrawLine()
    {
        _line.SetPosition(1, new Vector3(_parentPositionX, _parentPositionY, _cameraPositionZ));
        _line.enabled = false;
    }
}
