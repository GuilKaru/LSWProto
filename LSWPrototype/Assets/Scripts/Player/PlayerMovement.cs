using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D playerRb;
    public Animator playerAnim;
    public Animator clothesAnim;
    public Animator hairTopAnim;
    public Animator hairBottomAnim;

    private Vector2 lastMoveDir;
    private Vector2 moveDirection;

    private void Start()
    {
        clothesAnim.SetBool("Clothe1", true);
    }


    void Update()
    {
        GetInputs();
        Animate(playerAnim);
        Animate(clothesAnim);
        Animate(hairTopAnim);
        Animate(hairBottomAnim);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void GetInputs()
    {
        //take the input methods
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDir = moveDirection;
        }

        moveDirection = new Vector2(moveX, moveY).normalized; //normalize for diagonals
    }

     void Move()
    {
        playerRb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    void Animate(Animator animate)
    {
        animate.SetFloat("AnimMoveX", moveDirection.x);
        animate.SetFloat("AnimMoveY", moveDirection.y);
        animate.SetFloat("MoveMagnitude", moveDirection.magnitude);
        animate.SetFloat("LastMoveX", lastMoveDir.x);
        animate.SetFloat("LastMoveY", lastMoveDir.y);
    }
}
