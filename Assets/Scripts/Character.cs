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
    public GameObject hearts;
    public GameObject pointer;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = new Player(body, animator, spriteRenderer, bulletPrefab, firePoint, hearts, pointer);


    }

    // Update is called once per frame
    void Update()
    {
        mainCharacter.FrameChange();
    }
    

  
}
