using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    [Header("Components")]
    public GameObject player;
    public Rigidbody playerrigidbody;
    public Animator playerAnim;
    [Header("PlayerScripts")]
    public InputManager inputManager;
    public PlayerLocomotion playerLocomotion;
    public PlayerAnimation playerAnimation;
    [Header("Stats")]
    [Range(0, 50)]
    public float movementSpeed;
    [Range(0, 50)]
    public float rotationSpeed;
    public float sprintSpeed;
    public float walkSpeed;
    [Header("ActionStatus")]
    public bool isSprinting;
    public bool isWalking;
    public bool isJumping;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        inputManager = player.GetComponent<InputManager>();
        playerLocomotion = player.GetComponent<PlayerLocomotion>();
        playerrigidbody = player.GetComponent<Rigidbody>();
        playerAnimation = player.GetComponent<PlayerAnimation>(); 
        playerAnim = player.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        inputManager.HandleAllInput();   
    }
    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
}
