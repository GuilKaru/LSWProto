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
    public GameObject PlayerOutfit;
    public int Gold = 50;

    private Vector2 lastMoveDir;
    private Vector2 moveDirection;
    private string currentAnimation;
    private Sprite currentSprite;
    private int changeOutfit;
    [HideInInspector]
    public int currentOutfit;

    //Animation States
    const string Outfit_1 = "IdleOutfit1";
    const string Outfit_2 = "IdleOutfit2";
    const string Outfit_3 = "IdleOutfit3";

    private void Start()
    {
        changeOutfit = PlayerOutfit.GetComponent<OutfitChanger>().currentOption;
        
    }

    void Update()
    {
        
        currentOutfit = PlayerOutfit.GetComponent<OutfitChanger>().currentOption;
        currentSprite = PlayerOutfit.GetComponent<OutfitChanger>().options[currentOutfit];

        if (currentSprite == Items.GetSprite(Items.ItemType.Outfit_1))
        {
            ChangeAnimationState(Outfit_1);
        } 
        else if (currentSprite == Items.GetSprite(Items.ItemType.Outfit_2))
        {
            ChangeAnimationState(Outfit_2);
        } 
        else if (currentSprite == Items.GetSprite(Items.ItemType.Outfit_3))
        {
            ChangeAnimationState(Outfit_3);
        }

        //Debug.Log(currentOutfit);

        GetInputs();
        Animate(playerAnim);
        Animate(clothesAnim);
        Animate(hairTopAnim);
        Animate(hairBottomAnim);
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
}
