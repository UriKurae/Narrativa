using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;

    private bool canTriggerDialogue = false;
    private GameObject npcToDialogue;

    private CharacterController player;

    [Range(1, 10)]
    public float pSpeed = 5f;

    [Range(5, 15)]
    public float pSpeedRun = 10f;
    public float tmpSpeed = 10f;

    [Range(1, 10)]
    public float jumpForce = 5f;

    private float fallVelocity = 0f;
    private Vector3 movePlayer;
    public float gravity = 9.8f;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;


    //Variables de animacion
    public Animator playerAnminControl;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerAnminControl = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove,0, verticalMove);
        // Similar al normalize, sirve para que no pase de 1 la suma de las dos direcciones
        playerInput = Vector3.ClampMagnitude(playerInput,1);

        playerAnminControl.SetFloat("PlayerWalkVel",playerInput.magnitude * tmpSpeed);

        camDirection();
        // Hacer que hacia donde estemos mirando, sea recto para el player
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        // Velocidad del player
        movePlayer *= tmpSpeed;

        // Mirar hacia la direccion a la que nos vamos a mover
        player.transform.LookAt(player.transform.position+movePlayer);

        SetGravity();

        PlayerSkills(); 
               
        player.Move(movePlayer * Time.deltaTime);

        if (canTriggerDialogue && Input.GetKey(KeyCode.E))
        {
            TriggerDialogue trigger = npcToDialogue.GetComponent<TriggerDialogue>();

            if (trigger)
            {
                trigger.StartConversation();
            }
        }
    }


    private void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump")) 
        {
            fallVelocity = jumpForce;
            movePlayer.y = jumpForce;
            playerAnminControl.SetTrigger("PlayerJump");
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tmpSpeed = pSpeedRun;
        }
        else
        {
            tmpSpeed = pSpeed;
        }
        playerAnminControl.SetBool("IsRun", Input.GetKey(KeyCode.LeftShift));

       
    }

    private void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
            playerAnminControl.SetFloat("PlayerVerticalVel", player.velocity.y);

        }
        movePlayer.y = fallVelocity;
        playerAnminControl.SetBool("IsGrounded", player.isGrounded);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    private void OnAnimatorMove()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Npc")
        {
            canTriggerDialogue = true;
            npcToDialogue = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Npc")
        {
            canTriggerDialogue = false;
            npcToDialogue = null;
            TriggerDialogue trigger = other.gameObject.GetComponent<TriggerDialogue>();
            if (trigger)
            {
                trigger.EndConversation();
            }
        }
    }
}
