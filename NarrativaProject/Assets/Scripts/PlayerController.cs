using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;

    private CharacterController player;

    [Range(1, 10)]
    public float pSpeed = 5f;
    private float fallVelocity = 0f;
    private Vector3 movePlayer;
    public float gravity = 9.8f;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove,fallVelocity, verticalMove);
        // Similar al normalize, sirve para que no pase de 1 la suma de las dos direcciones
        playerInput = Vector3.ClampMagnitude(playerInput,1);

        camDirection();
        // Hacer que hacia donde estemos mirando, sea recto para el player
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer *= pSpeed;

        // Mirar hacia la direccion a la que nos vamos a mover
        player.transform.LookAt(player.transform.position+movePlayer);


        SetGravity();
        player.Move(movePlayer * Time.deltaTime);


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
        }
        movePlayer.y = fallVelocity;
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

}
