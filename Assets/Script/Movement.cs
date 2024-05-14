using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
// using Shooting;


public class Movement : MonoBehaviour
{
  // Start is called before the first frame update
  private Animator animator;
  public ParticleSystem dashEffect;

  public GameObject rotatePoint;
  public Vector3 mousePos;

  public bool flipRight = true;

  private float inputHorizontal, inputVertical;

  private bool inputShift;
  public float moveSpeed = 5f;
  public Rigidbody2D rb;
  private bool isAnimatingDeath = false;

  public bool playerDeath = false;

  private bool canDash = true;
  private bool isDashing;
  public float dashingPower = 25f;
  private float dashingTime = 0.2f;
  private float dashingCoolDown = 0.1f;
  private TrailRenderer tr;

  public Shooting shoot, shooting;
  public GameManagerScript gameManager;

  public bool movement = true;

  public void Shoot(bool canMove)
  {

    movement = canMove;
  }
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




    if (movement)
    {
      if (isDashing)
      {
        return;
      }
      inputHorizontal = Input.GetAxisRaw("Horizontal");
      inputVertical = Input.GetAxisRaw("Vertical");
      inputShift = Input.GetKeyDown(KeyCode.LeftShift);
      mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    rb.velocity = new Vector2(inputHorizontal * moveSpeed, inputVertical * moveSpeed);

    if (inputShift && canDash)
    {
      StartCoroutine(Dash());
      // animator.SetBool("dashing", false);

    }

    // Flip character
    if (mousePos.x > transform.position.x && !flipRight)
    {
      FlipPlayer();
    }

    if (mousePos.x < transform.position.x && flipRight)
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

  public void FlipPlayer()
  {
    // Vector3 currentscale = transform.localScale;
    // currentscale.x *= -1;
    // transform.localScale = currentscale;
    flipRight = !flipRight;

    transform.Rotate(0f, 180f, 0f);

    // var effectScale = dashEffect.transform.localScale;
    // effectScale.x *= -1;
    // dashEffect.transform.localScale = effectScale;

    rotatePoint = transform.Find("Rotate Point").gameObject;
    Vector3 rotateScale = rotatePoint.transform.localScale;
    rotateScale.y *= -1;
    rotatePoint.transform.localScale = rotateScale;




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

  private void OnCollisionEnter2D(Collision2D other)
  {

    if (other.gameObject.CompareTag("Wolf") && !isAnimatingDeath)
    {
      rb.mass = 5;
      shooting = FindObjectOfType<Shooting>();
      movement = false;
      canDash = false;
      shooting.Shoot(false);
      moveSpeed = 0;
      isAnimatingDeath = true;
      if (isAnimatingDeath)
      {
        playerDeath = true;
        animator.SetBool("dead", playerDeath);

      }
      StartCoroutine(DestroyAfterAnimation());
    }



  }

  private IEnumerator DestroyAfterAnimation()
  {
    float deathAnimationDuration = animator.GetCurrentAnimatorStateInfo(0).length + 0.6f;

    yield return new WaitForSeconds(deathAnimationDuration);
    // Destroy(gameObject);
    // EnemyMovement()

    gameObject.SetActive(false);
    gameManager = FindObjectOfType<GameManagerScript>();

    gameManager.GameOverPopup();
  }
}







