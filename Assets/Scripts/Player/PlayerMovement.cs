using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //TODO: BLOCK MOVEMENT WHEN UI IS OPEN


    [Header("References")]
    [SerializeField] private Rigidbody2D playerRigidBody;

    [Header("Movement Variables")]
    [SerializeField] private float playerSpd = 0.003f;
    private Vector2 moveInput = Vector2.zero;

    [Header("Player Interaction Variables")]
    [SerializeField] BoxCollider2D interactionCollider;
    Vector3 colliderUpVector = new Vector2(0, 0.5f);
    Vector3 colliderDownVector = new Vector2(0, -0.5f);
    Vector3 colliderRightVector = new Vector2(0.35f, 0);
    Vector3 colliderLeftVector = new Vector2(-0.35f, 0);

    void FixedUpdate()
    {
        PlayerMove();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        PlayerChangeDirection();
    }

    private void PlayerMove()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + (moveInput * Time.deltaTime * playerSpd));
    }

    private void PlayerChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeInteractorPosition(colliderUpVector);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeInteractorPosition(colliderDownVector);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeInteractorPosition(colliderRightVector);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeInteractorPosition(colliderLeftVector);
        }
    }
    
    private void ChangeInteractorPosition(Vector2 newPos)
    {
        if(newPos == interactionCollider.offset) 
        {
            return;
        }
        interactionCollider.offset = newPos;
    }
}
