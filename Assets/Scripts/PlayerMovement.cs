using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //PUNIO2 Survival
    
    #region MyCode
    /*
    private Animator _animator;
    private Rigidbody _rb;

    #region Movement Controls
    [SerializeField] private InputActionReference move;
    private Vector3 _move;
    [SerializeField] private float _walkSpeed, _runSpeed, _crouchSpeed;
    #endregion

    #region bools
    public bool _isDead;
    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        if (!_isDead) Move();

    }

    void GetInput()
    {
        _move = move.action.ReadValue<Vector2>();

    }

    void Move()
    {
        _rb.velocity = _move * _walkSpeed * Time.fixedDeltaTime;
    }

    void GetObject()
    {

    }

    void Use()
    {

    }*/
    #endregion


    #region Pasted Code
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    #endregion
}
