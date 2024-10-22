using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveForce = 5f;
    public float jumpForce = 11f;
    public float movementX;
    public float movementY;

    public Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string RUN_ANIMATION = "Move";
    private bool facingRight = true;


    void Awake()
    {
        this.myBody = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.sr = GetComponent<SpriteRenderer>();

    }
    public void AnimatePlayer()
    {

        if (this.movementX != 0 || this.movementY != 0)
        {
            anim.SetBool(RUN_ANIMATION, true);
        }
        else
        {
            anim.SetBool(RUN_ANIMATION, false);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
    }
    void PlayerMoveKeyboard()
    {
        this.movementX = Input.GetAxis("Horizontal");
        Debug.Log("move X value is: " + this.movementX);
        if (movementX < 0){
                FlipCharacter(true);

        }
        else{
                FlipCharacter(false);

        }
        this.movementY = Input.GetAxis("Vertical");
        Debug.Log("move Y value is: " + this.movementY);




        AnimatePlayer();


        Vector2 movement = new Vector2(this.movementX * this.moveForce, this.movementY * this.moveForce);
        this.myBody.velocity = movement;

    }
        void FlipCharacter(bool faceRight)
    {
        facingRight = faceRight;
        Vector3 localScale = transform.localScale;
        localScale.x = faceRight ? 1 : -1;
        transform.localScale = localScale;
    }

}
