
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
    private Transform _firePoint;
    private int _health = 10;

    private float _moveforce = 5f; // same as speed
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

    public double GetSpeed()
    {
        return (double)_moveforce;
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
        _moveforce = speed;
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
        PlayerMoveKeyboard();
        BulletShoot();
    }

    public void AddHealth(int amount)
    {
        _health += amount;
        ShowHearts();
    }

    public void AddDamage(float amount)
    {
        _damage += amount;
    }

    private void ShowHearts()
    {
        for (int i = 0; i < this._health; i++)
        {
            Vector2 heartPosition = new Vector2(-this._heartLocation + (0.3f * i), this._heartLocation);
            GameObject heart = UnityEngine.Object.Instantiate(this._hearts, heartPosition, Quaternion.identity, this._playerTransform);
        }
    }

    private void PlayerMoveKeyboard()
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

    private void BulletShoot()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject bullet = UnityEngine.Object.Instantiate(this._bulletPrefab, this._firePoint.position, this._firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = this._firePoint.right * this._bulletSpeed;
            UnityEngine.Object.Destroy(bullet, 5f);
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
