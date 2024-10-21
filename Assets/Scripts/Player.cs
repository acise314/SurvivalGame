using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveForce = 10f;
    public float jumpForce = 11f;
    public float movementX;
    public Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string RUN_ANIMATION = "Move";

    void Awake(){
        this.myBody = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        this.sr = GetComponent<SpriteRenderer>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
