using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Player mainCharacter;

    // Assign these via the Unity Editor or find them in Start()
    public Rigidbody2D body;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = new Player(body, animator, spriteRenderer, bulletPrefab, firePoint);


    }

    // Update is called once per frame
    void Update()
    {
        mainCharacter.PlayerMoveKeyboard();
        mainCharacter.BulletShoot();

    }
    

  
}
