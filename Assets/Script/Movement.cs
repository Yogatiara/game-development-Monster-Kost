using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    bool flipRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(inputHorizontal * moveSpeed, inputVertical * moveSpeed);

        // Flip character
        if (inputHorizontal > 0 && !flipRight)
        {
            FlipPlayer();
        }

        if (inputHorizontal < 0 && flipRight)
        {
            FlipPlayer();
        }
    }

    void FlipPlayer()
    {
        Vector3 currentscale = gameObject.transform.localScale;
        currentscale.x *= -1;
        gameObject.transform.localScale = currentscale;

        flipRight = !flipRight;
    }
}

