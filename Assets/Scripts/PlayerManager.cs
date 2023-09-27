using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public GameObject player;
    public Rigidbody rigidbody;
    public InputManager inputManager;
    public PlayerLocomotion playerLocomotion;
    [Range(0, 50)]
    public float movementSpeed;
    [Range(0, 50)]
    public float rotationSpeed;

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
        rigidbody = player.GetComponent<Rigidbody>();
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
