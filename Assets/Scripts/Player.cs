
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

    private float _moveForce = 5f; // same as speed
    private float _damage = 5f;
    private int _score = 0;
    private float _rotationSpeed = 100f;
    private KeyCode _spinKeyClockwise = KeyCode.J;
    private KeyCode _shootKey = KeyCode.K;
    private KeyCode _spinKeyCounterClockwise = KeyCode.L;

    private float _movementX;
    private float _movementY;
    private float _bulletSpeed = 10f;

    private const string RUN_ANIMATION = "Move";
    private bool _facingRight = true;
    private float _heartLocation = 4.5f;
    private Transform _playerTransform;
    public Player(Transform playerTransform, Rigidbody2D body, Animator animator, SpriteRenderer spriteRenderer, GameObject bullet, Transform firePoint, GameObject heart, GameObject pointer)
    {
        this._myBody = body;
        this._anim = animator;
        this._sr = spriteRenderer;
        this._bulletPrefab = bullet;
        this._firePoint = firePoint;
        this._hearts = heart;
        this._pointer = pointer;
        this._playerTransform = playerTransform;
        this._anim.speed = 0;
        showHearts();

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

    public double GetSpeed()
    {
        return (double) _moveForce;
    }
    public double GetDamage()
    {
        return (double)_damage;
    }
    public int GetScore()
    {
        return _score;
    }

    public void SetSpeed(float speed)
    {
        _moveForce = speed;
    }
    public void SetDamage(float damage)
    {
        _damage = damage;
    }
    public void IncreaseScore(int points)
    {
        _score += points;
    }
    public void FrameChange()
    {
        playerMoveKeyboard();
        bulletShoot();
        spin();
    }

    public void AddHealth(int amount)
    {
        _health += amount;
        showHearts();
    }

    public void AddDamage(float amount)
    {
        _damage += amount;
    }

    private void showHearts()
    {
        for (int i = 0; i < this._health; i++)
        {
            Vector2 heartPosition = new Vector2(-this._heartLocation + (0.3f * i), this._heartLocation);
            GameObject heart = UnityEngine.Object.Instantiate(this._hearts, heartPosition, Quaternion.identity, this._playerTransform);
            //  heart.transform.SetParent(this._playerTransform, false);
        }
    }

    private void playerMoveKeyboard()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(movementX * this._moveForce, movementY * this._moveForce);
        this._myBody.velocity = movement;

        if (movementX < 0)
        {
            FlipCharacter(false);
        }
        else if (movementX > 0)
        {
            FlipCharacter(true);
        }

        _anim.SetBool(RUN_ANIMATION, movementX != 0 || movementY != 0);
    }

    private void bulletShoot()
    {
        if (Input.GetKeyDown(this._shootKey))
        {
            GameObject bullet = UnityEngine.Object.Instantiate(this._bulletPrefab, this._firePoint.position, this._firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = this._firePoint.right * this._bulletSpeed;
            UnityEngine.Object.Destroy(bullet, 5f);
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


    private void FlipCharacter(bool faceRight)
    {
        if (_facingRight != faceRight)
        {
            _sr.flipX = !_sr.flipX;
        }
        _facingRight = faceRight;
    }
}
