using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
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

    public GameObject bulletPrefab;
    public int numBullets = 1;
    public float bulletSpeed = 10f;
    public Transform firePoint;
    public Vector2 lookDirection;
    float lookAngle;

    public Player(Rigidbody2D body, Animator animator, SpriteRenderer spriteRenderer, GameObject bullet, Transform firePt)
    {
        this.myBody = body;
        this.anim = animator;
        this.sr = spriteRenderer;
        this.bulletPrefab = bullet;
        this.firePoint = firePt;
        anim.speed = 0;
    }
    public void AnimatePlayer()
    {

        if (this.movementX != 0 || this.movementY != 0)
        {
            anim.SetBool(RUN_ANIMATION, true);
            anim.speed = 0.75f;
        }
        else
        {
            anim.SetBool(RUN_ANIMATION, false);
            anim.speed = 0;
        }
    }

    public void BulletShoot()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = UnityEngine.Object.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = firePoint.right * bulletSpeed;
        }

    }
    public void PlayerMoveKeyboard()
    {
        this.movementX = Input.GetAxis("Horizontal");
        Debug.Log("move X value is: " + this.movementX);
        if (movementX < 0)
        {
            FlipCharacter(false);

        }
        else if (movementX > 0)
        {
            FlipCharacter(true);
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
        Vector2 localScale = sr.transform.localScale;
        localScale.x = faceRight ? 1 : -1;
        sr.transform.localScale = localScale;
    }

}