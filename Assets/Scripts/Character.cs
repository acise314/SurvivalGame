using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    private Player mainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GetComponent<Player>();


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
    }
    
    void PlayerMoveKeyboard(){
        mainCharacter.movementX=Input.GetAxis("Horizontal");
        Debug.Log("move X value is: " + mainCharacter.movementX);

    Vector2 movement = new Vector2(mainCharacter.movementX * mainCharacter.moveForce, mainCharacter.myBody.velocity.y);
    mainCharacter.myBody.velocity = movement;

    }

  
}
