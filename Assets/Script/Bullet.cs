using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

  private Vector3 mousePos;
  private Camera mainCamera;
  private Rigidbody2D rb;
  public float force;
  public float maxDistance;
  private float traveledDistance;
  private Vector3 lastVelocity;
  private float rot;
  private Vector3 direction;

  private SpriteRenderer rend;
  private Animator anim;
  private RuntimeAnimatorController bulletFlyAnimator, bulletIdleAnimator;

  private Collider2D colider;

  private Sprite bulletFly, bulletIdle;

  public Shooting shooting;



  void Start()
  {
    mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    rb = GetComponent<Rigidbody2D>();
    mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    direction = mousePos - transform.position;
    Vector3 rotation = transform.position - mousePos;
    rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0, 0, rot);


    rend = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    colider = GetComponent<CircleCollider2D>();

    // bulletFly = Resources.Load<Sprite>("eye fire1");
    bulletFlyAnimator = Resources.Load<RuntimeAnimatorController>("Bullet");
    // bulletIdle = Resources.Load<Sprite>("Bullet Idle");
    bulletIdleAnimator = Resources.Load<RuntimeAnimatorController>("Bullet Idle");

    // rend.sprite = bulletFly;
    // anim.runtimeAnimatorController = bulletFlyAnimator;



  }

  void Update()
  {
    lastVelocity = rb.velocity;
    traveledDistance += rb.velocity.magnitude * Time.deltaTime;

    if (traveledDistance >= maxDistance)
    {
      StopBullet();
      anim.runtimeAnimatorController = bulletIdleAnimator;
      rend.sprite = bulletIdle;

      transform.rotation = Quaternion.Euler(0, 0, 0);

    }
  }

  private void OnCollisionEnter2D(Collision2D col)
  {

    var speed = lastVelocity.magnitude;
    var firstContact = col.contacts[0];
    Vector2 direction = Vector2.Reflect(lastVelocity.normalized, firstContact.normal);
    rb.velocity = direction * speed;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0, 0, angle + 180);

  }

  private void StopBullet()
  {
    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    rb.velocity = Vector2.zero;
    spriteRenderer.sortingOrder = -1;
    colider.isTrigger = true;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      Destroy(gameObject);
      shooting = FindObjectOfType<Shooting>();

      shooting.Shoot(true);

      // shootingReference.canFire = false;
    }

  }
}
