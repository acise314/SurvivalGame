using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character : MonoBehaviour
{
    private Player mainCharacter;

    public Rigidbody2D body;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject hearts;
    public GameObject pointer;
    public Transform playerTransform;
    public TextMeshProUGUI info;

    void Start()
    {
        mainCharacter = new Player(playerTransform, body, animator, spriteRenderer, bulletPrefab, firePoint, hearts, pointer);
        info.text = $"SPEED: {mainCharacter.GetSpeed()}\nDAMAGE: {mainCharacter.GetDamage()}\nSCORE: {mainCharacter.GetScore()}";
    }

    void Update()
    {
        mainCharacter.FrameChange();
    }
      
}
