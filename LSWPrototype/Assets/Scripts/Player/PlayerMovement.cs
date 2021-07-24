using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Reference to Animator so you can Animate different parts of the Sprites
    public Animator playerAnim;
    public Animator clothesAnim;
    public Animator hairTopAnim;
    public Animator hairBottomAnim;

    public GameObject PlayerOutfit;
    [HideInInspector]
    public int currentOutfit;
    private int changeOutfit;
    private string currentAnimation;
    private Sprite currentSprite;

    // Movement Variables
    public Rigidbody2D playerRb;
    public float speed;
    public int Gold = 50;

    private Vector2 lastMoveDir;
    private Vector2 moveDirection;

    private void Start()
    {
        changeOutfit = PlayerOutfit.GetComponent<OutfitChanger>().currentOption;
        
    }

    void Update()
    {
        //See what Outfit you are wearing
        WhatIsYourOutfit();
        //Movement Inputs
        GetInputs();
        //Animate
        DoAnimation();
    }

    private void FixedUpdate()
    {
        if (!PauseMenu.isPaused)
        {
            Move();
        }
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

    void ChangeAnimationState(string newState)
    {
        if (currentAnimation == newState) return;

        clothesAnim.Play(newState);
        playerAnim.Play("Idle", 0, 0.0f);
        hairTopAnim.Play("Idle", 0, 0.0f);
        hairBottomAnim.Play("Idle", 0, 0.0f);

        currentAnimation = newState;
    }

    private void WhatIsYourOutfit()
    {
        AreYouTheSame(Items.ItemType.Outfit_1);
        AreYouTheSame(Items.ItemType.Outfit_2);
        AreYouTheSame(Items.ItemType.Outfit_3);
        AreYouTheSame(Items.ItemType.Outfit_4);
        AreYouTheSame(Items.ItemType.Outfit_5);
    }

    //Check if the outfit you are trying to animate is the same that you're wearing
    public bool AreYouTheSame(Items.ItemType itemType)
    {
        currentOutfit = PlayerOutfit.GetComponent<OutfitChanger>().currentOption;
        currentSprite = PlayerOutfit.GetComponent<OutfitChanger>().options[currentOutfit];

        if (currentSprite == Items.GetSprite(itemType))
        {
            ChangeAnimationState(Items.GetAnimation(itemType));
            return true;
        } else
        {
            return false;
        }
    }

    private void DoAnimation()
    {
        Animate(playerAnim);
        Animate(clothesAnim);
        Animate(hairTopAnim);
        Animate(hairBottomAnim);
    }
}
