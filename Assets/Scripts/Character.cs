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
    public TextMeshProUGUI gameOverText; 


    void Start()
    {
        mainCharacter = new Player(playerTransform, body, animator, spriteRenderer, bulletPrefab, firePoint, hearts, pointer);
        info.text = $"SPEED: {mainCharacter.GetSpeed()}\nDAMAGE: {mainCharacter.GetDamage()}\nSCORE: {mainCharacter.GetScore()}";

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            UnityEngine.GameObject.Destroy(collision.gameObject);
            mainCharacter.changeHealth(-1);
            if (mainCharacter.getHealth() <= 0)
            {
                GameOver();
            }
        }


    }
    private void GameOver()
    {
        gameOverText.gameObject.SetActive(true); 
        Time.timeScale = 0;
    }


void Update()
{
    mainCharacter.FrameChange();
}
private void ifKilled()
{
    if (mainCharacter.GetDamage() < 0)
    {
        UnityEngine.Object.Destroy(this);
    }
}

}
