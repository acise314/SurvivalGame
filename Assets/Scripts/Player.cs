using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private Rigidbody2D _myBody;
    private SpriteRenderer _sr;
    private Animator _anim;
    private GameObject _bulletPrefab;
    private GameObject _hearts;
    private GameObject _pointer;
    private Transform _firePoint;

    private int _health = 10;
    private float _moveforce = 5f; // same as speed
    private float _damage = 5f;
    private int _numBullets = 1;
    private float _jumpForce = 11f;
    private float _rotationSpeed = 100f;
    private KeyCode _spinKeyClockwise = KeyCode.J;
    private KeyCode _shootKey = KeyCode.K;
    private KeyCode _spinKeyCounterClockwise = KeyCode.L;

    private float _movementX;
    private float _movementY;
    private float _bulletSpeed = 10f;
    private Vector2 _lookDirection;
    private float _lookAngle;

    private const string RUN_ANIMATION = "Move";
    private bool _facingRight = true;
    private float _heartLocation = 4.5f;
    private Transform _playerTransform;

    public Player(Transform playerTransform, Rigidbody2D body, Animator animator, SpriteRenderer spriteRenderer, GameObject bullet, Transform firePoint, GameObject hearts, GameObject pointer)
    {
        this._myBody = body;
        this._anim = animator;
        this._sr = spriteRenderer;
        this._bulletPrefab = bullet;
        this._firePoint = firePoint;
        this._hearts = hearts;
        this._pointer = pointer;
        this._playerTransform = playerTransform;
        this._anim.speed = 0; // Initialize animator speed
        showHearts();

    }

    public void FrameChange()
    {
        playerMoveKeyboard();
        bulletShoot();
        spin();

    }
    private void showHearts()
    {
        for (int i = 0; i < this._health; i++)
        {
            Vector2 heartPosition = new Vector2(-this._heartLocation + (0.3f * i), this._heartLocation);
            GameObject heart = UnityEngine.Object.Instantiate(this._hearts, heartPosition, Quaternion.identity);
            heart.transform.SetParent(this._playerTransform);
        }
    }

    private void animatePlayer()
    {
        if (this._movementX != 0 || this._movementY != 0)
        {
            this._anim.SetBool(RUN_ANIMATION, true);
            this._anim.speed = 0.75f;
        }
        else
        {
            this._anim.SetBool(RUN_ANIMATION, false);
            this._anim.speed = 0;
        }
    }

    private void bulletShoot()
    {
        if (Input.GetKeyDown(this._shootKey))
        {
            GameObject bullet = UnityEngine.Object.Instantiate(this._bulletPrefab, this._firePoint.position, this._firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = this._firePoint.right * this._bulletSpeed;
        }
    }

    private void playerMoveKeyboard()
    {
        spin();
        this._movementX = Input.GetAxis("Horizontal");
        Debug.Log("move X value is: " + this._movementX);
        if (this._movementX < 0)
        {
            flipCharacter(false);
        }
        else if (this._movementX > 0)
        {
            flipCharacter(true);
        }
        this._movementY = Input.GetAxis("Vertical");
        Debug.Log("move Y value is: " + this._movementY);

        animatePlayer();

        Vector2 movement = new Vector2(this._movementX * this._moveforce, this._movementY * this._moveforce);
        this._myBody.velocity = movement;
    }

    private void flipCharacter(bool faceRight)
    {
        if (this._facingRight != faceRight)
        {
            this._sr.flipX = !this._sr.flipX;
        }
        this._facingRight = faceRight;
    }

    private void spin()
    {
        if (Input.GetKey(this._spinKeyClockwise))
        {
            this._firePoint.Rotate(0, 0, this._rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(this._spinKeyCounterClockwise))
        {
            this._firePoint.Rotate(0, 0, -1 * this._rotationSpeed * Time.deltaTime);
        }
        updatePointer();
    }

    private void updatePointer()
    {
        this._pointer.transform.position = this._firePoint.position;
        float angle = this._firePoint.eulerAngles.z - 45.0f;
        this._pointer.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
