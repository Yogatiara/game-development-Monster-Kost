using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyMovement : MonoBehaviour
{
  // Start is called before the first frame update
  private Animator animator;

  public Transform target;
  public float speed = 3f;
  // private Rigidbody2D rb;
  public static bool isAnimatingDeath = false;

  public Movement movement;

  private EnemySpawner enemySpawner;

  public static int enemies = 0;

  public GameManagerScript gameManager;

  void Start()
  {
    GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

    // Memeriksa apakah objek player ditemukan
    if (playerObject != null)
    {
      // Jika ditemukan, ambil komponen transform
      target = playerObject.transform;
    }
    animator = GetComponent<Animator>();

    // rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {

    if (!target)
    {

      Destroy(gameObject);

    }
    else
    {
      movement = FindObjectOfType<Movement>();

      if (movement != null)
      {
        if (movement.playerDeath)
        {
          enemySpawner = FindObjectOfType<EnemySpawner>();
          enemySpawner.Spawn(false);

          if (isAnimatingDeath)
          {
            speed = 0f;
          }
          else
          {
            speed = 2.5f;

          }


          target = GameObject.FindGameObjectWithTag("Respawn").transform;
          StartCoroutine(DestroyObject());
        }

      }

      FollowTarget();

    }

    // Debug.Log(movement.playerDeath);


  }


  void FollowTarget()
  {

    Vector3 direction = (target.position - transform.position).normalized;

    if (direction.x < 0)
    {
      if (transform.rotation.eulerAngles.y != 180f)
      {
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
      }
    }
    else
    {
      if (transform.rotation.eulerAngles.y != 0f)
      {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
      }
    }

    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

  }


  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("BulletIdle") && !isAnimatingDeath)
    {
      enemySpawner = FindObjectOfType<EnemySpawner>();

      speed = 0;
      isAnimatingDeath = true;
      animator.SetBool("isDead", isAnimatingDeath);
      StartCoroutine(DestroyAfterAnimation());


      if (EnemySpawner.maxEnemies == 1)
      {

        StartCoroutine(ShowWinnerPopUp());
      }

    }


  }
  private IEnumerator ShowWinnerPopUp()
  {

    yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + 0.3f);
    gameManager = FindObjectOfType<GameManagerScript>();

    gameManager.PopUpwinTheGame();



  }

  private IEnumerator DestroyAfterAnimation()
  {
    float deathAnimationDuration = animator.GetCurrentAnimatorStateInfo(0).length + 0.3f;

    yield return new WaitForSeconds(deathAnimationDuration);
    Destroy(gameObject);


  }

  private IEnumerator DestroyObject()
  {
    yield return new WaitForSeconds(0.5f);
    Destroy(gameObject);

  }


}
