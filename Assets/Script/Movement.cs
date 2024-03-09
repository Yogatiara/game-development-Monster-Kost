using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private float inputHorizontal, inputVertical;
    private Animator animator;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    bool flipRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

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

        AnimationUpdate();
    }

    void AnimationUpdate()
    {
        if (inputHorizontal != 0f || inputVertical != 0f)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
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

