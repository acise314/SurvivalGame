using UnityEngine;

public class Character : MonoBehaviour
{
    private Player mainCharacter;

    public Rigidbody2D body;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject hearts;

    void Start()
    {
        mainCharacter = new Player(this, body, animator, spriteRenderer, bulletPrefab, firePoint, hearts);
    }

    void Update()
    {
        mainCharacter.FrameChange();
    }
}
