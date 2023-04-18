using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, IDragHandler
{
    [HideInInspector] [SerializeField] private CharacterController _character;
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private float _jumpForce = 10;

    private Vector3 _velocity = Vector3.zero;

    private void OnValidate()
    {
        _character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouse = Input.GetAxis("Mouse X");
        var jump = Input.GetAxis("Jump");

        RotateCharacter(mouse);
        Move(horizontal, vertical, jump);
    }

    private void RotateCharacter(float mouse)
    {
        transform.Rotate(Vector3.up, mouse);
    }

    private void Move(float horizontal, float vertical, float jump)
    {
        var dir = new Vector3(horizontal, 0, vertical);
        var moveVector = transform.TransformDirection(dir) * _moveSpeed;

        if (_character.isGrounded)
        {
            if (_velocity.y < 0)
            {
                _velocity.y = 0;
            }

            if (jump != 0)
            {
                _velocity.y += _jumpForce;
            }
        }

        _velocity.y += -9.81f * Time.deltaTime;

        _character.Move((moveVector + _velocity) * Time.deltaTime);
    }
}