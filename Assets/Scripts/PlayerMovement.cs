using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayeMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3.5f;

    private Vector2 _movement;

    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 lastMoveDirection;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";

    public Transform Aim;
    bool isWalking = false;




    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        _rb.velocity = _movement * _moveSpeed;

        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);

        if (_movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, _movement.x);
            _animator.SetFloat(_lastVertical, _movement.y);
            isWalking = true;
            lastMoveDirection = _movement;
            Vector3 vector3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
        else if (_movement.x != 0 || _movement.y != 0)
        {
            isWalking = true;
        }

        if(_movement == Vector2.zero)
        {
            _animator.Play("Player_Idle");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && _movement.x>0f)
        {
            _animator.SetTrigger("PunchAttackRight");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && _movement.x < 0f)
        {
            _animator.SetTrigger("PunchAttackLeft");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && _movement.y > 0f)
        {
            _animator.SetTrigger("PunchAttackBack");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && _movement.y < 0f)
        {
            _animator.SetTrigger("PunchAttackFace");
        }

    }

    private void FixedUpdate()
    {
        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * _movement.x + Vector3.down * _movement.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }


}
