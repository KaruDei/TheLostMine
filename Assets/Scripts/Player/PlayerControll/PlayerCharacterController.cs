using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private TouchPanel _touchPanel;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private const float _gravity = -9.81f;
    
    private Vector3 _directionMove;
    private Vector3 _velocity;
    private bool _isJump;

    private void FixedUpdate()
    {
        _directionMove = _joystick.GetDirection();
        Move();
        Rotate();
    }

    private void Move()
    {
        if (_characterController.isGrounded)
        {
            _velocity.y = -1f;
            if (_isJump)
            {
                _velocity.y = _jumpForce;
            }
        }
        else 
            _velocity.y -= _gravity * -2f * Time.fixedDeltaTime;

        if (_directionMove.magnitude != 0)
        {
            // Передвижение персонажа
            _characterController.Move(transform.TransformDirection(_directionMove) * _speed * Time.fixedDeltaTime);
        }

        // Гравитация
        _characterController.Move(_velocity * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        _cameraController.LookAxis = _touchPanel.GetTouchDirection();
    }

    public void DownJumpButton()
    {
        _isJump = true;
    }
    public void UpJumpButton()
    {
        _isJump = false;
    }
}
