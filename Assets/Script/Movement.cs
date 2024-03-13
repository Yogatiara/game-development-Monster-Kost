using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public ParticleSystem dashEffect;

    private float inputHorizontal, inputVertical;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    bool flipRight = true;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 25f;
    private float dashingTime = 0.2f;
    private float dashingCoolDown = 0.1f;
    private TrailRenderer tr;


    void Start()
    {
        // activeMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isDashing)
        {
            return;
        }
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(inputHorizontal * moveSpeed, inputVertical * moveSpeed);

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
            // animator.SetBool("dashing", false);

        }

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





        // if (Input.GetKeyDown(KeyCode.LeftShift))
        // {

        //     yield return new WaitForSeconds(30f);

        // }

        // Thread.Sleep((int)dashingTime);
        // animator.SetBool("dashing", false);

    }

    void FlipPlayer()
    {


        Vector3 currentscale = gameObject.transform.localScale;
        currentscale.x *= -1;
        gameObject.transform.localScale = currentscale;

        flipRight = !flipRight;

        var effectScale = dashEffect.transform.localScale;
        effectScale.x *= -1;
        dashEffect.transform.localScale = effectScale;

    }

    void CreateEffect()
    {
        dashEffect.Play();

    }



    IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        Vector2 dashDirection = new Vector2(inputHorizontal, inputVertical).normalized;
        rb.velocity = dashDirection * dashingPower;

        // rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        dashEffect.Play();
        yield return new WaitForSeconds(dashingTime);

        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashingCoolDown);

        canDash = true;

    }
}

