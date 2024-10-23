using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    public float speed;
    private float movementx;
    private float movementy;

    [SerializeField]
    private Renderer bgRenderer;



    // Update is called once per frame
    void Update()
    {
        movementx = Input.GetAxisRaw("Horizontal");
        movementy = Input.GetAxisRaw("Vertical");
        if (movementx > 0)
        {
            bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        }

        if (movementx < 0)
        {
            bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime * -1, 0);
        }

        if (movementy > 0)
        {
            bgRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime * 3);
        }

        if (movementy < 0)
        {
            bgRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime * -3);
        }

        else
        {
            bgRenderer.material.mainTextureOffset += new Vector2(0, 0);
        }
    }

}