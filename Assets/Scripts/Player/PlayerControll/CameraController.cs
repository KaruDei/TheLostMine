using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _sensyvity = 40f;
    private float _xMove;
    private float _yMove;
    private float _yRotation;

    public Vector2 LookAxis;

    private void FixedUpdate()
    {
        _xMove = LookAxis.x * _sensyvity * Time.fixedDeltaTime;
        _yMove = LookAxis.y * _sensyvity * Time.fixedDeltaTime;
        _yRotation -= _yMove;
        _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_yRotation, 0, 0);
        _player.Rotate(Vector3.up * _xMove);
    }
}
