using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Fields")]
    private PlayerControls _playerControls;
    private InputAction move;

    [Header("Movement Stats")]
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private float _movementForce = 1f;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private float _maxSpeed = 5f;
    public Vector3 _forceDirection = Vector3.zero;

    [Header("Camera Linking")]
    [SerializeField]
    private Camera _playerCamera;

    //on awake, the rigidbody is found and a new player controls is linked to the player
    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();
        _playerControls = new PlayerControls();
    }

    //these will ensure that the system can detect input or not and will enable or disable the inputs if not detected
    private void OnEnable()
    {
        _playerControls.Player.Jump.started += DoJump;
        move = _playerControls.Player.Move;
        _playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Player.Jump.started -= DoJump;
        _playerControls.Player.Disable();
    }

    //this will do generally everything in terms of movement and gravity control for the jump to not make it as floaty
    private void FixedUpdate()
    {
        _forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(_playerCamera) * _movementForce;
       _forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(_playerCamera) * _movementForce;

        _rb.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        if (_rb.velocity.y < 0f)
            _rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 _horizontalVelocity = _rb.velocity;
        _horizontalVelocity.y = 0;
        if (_horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
            _rb.velocity = _horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rb.velocity.y;

        LookAt();
        
    }

    //This will prevent the player from constantly rotating and will focus on rotating based on the input you send it
    private void LookAt()
    {
        Vector3 direction = _rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this._rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            _rb.angularVelocity = Vector3.zero;
    }
    
    //These will let the player move while tracking the cameras general rotation so that the player may move independantly
    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = _playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = _playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    //once the boolean below is set to true, and the player hits the jump button, the player will jump
    public void DoJump(InputAction.CallbackContext obj)
    {
        //Debug.Log(_isGrounded());
        if (_isGrounded())
        {
            _forceDirection += Vector3.up * _jumpForce;
        }
    }

    private bool _isGrounded()
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position, -transform.up * .53f, Color.red);
        if (Physics.Raycast(transform.position, -transform.up, out hit, .53f))
            return true;
        else
            return false;
    }
}
