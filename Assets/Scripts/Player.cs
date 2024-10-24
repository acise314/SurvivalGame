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
    private float _moveForce = 5f;
    private float _damage = 5f;
    private float _bulletSpeed = 10f;

    private const string RUN_ANIMATION = "Move";
    private bool _facingRight = true;

    private MonoBehaviour _character;

    public Player(MonoBehaviour character, Rigidbody2D body, Animator animator, SpriteRenderer spriteRenderer, GameObject bullet, Transform firePoint, GameObject heart)
    {
        this._myBody = body;
        this._anim = animator;
        this._sr = spriteRenderer;
        this._bulletPrefab = bullet;
        this._firePoint = firePoint;
        this._hearts = heart;
        this._character = character;
        ShowHearts();
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
            Vector2 heartPosition = new Vector2(-4.5f + (0.3f * i), 4.5f);
            GameObject heart = UnityEngine.Object.Instantiate(this._hearts, heartPosition, Quaternion.identity);
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
