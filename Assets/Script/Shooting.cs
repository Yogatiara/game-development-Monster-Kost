using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
  private Camera mainCamera;
  public Movement movementReference;
  public GameObject bulletPrefab;
  public Transform weapons;
  private GameObject currentBullet;
  public bool canFire = true;

  private float timer;
  public float timeBetweenFiring;


  public LayerMask wallLayer;


  public void Shoot(bool canShoot)
  {

    canFire = canShoot;
  }
  // }
  void Start()
  {
    mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
  }



  void Update()
  {
    // Debug.Log(canFire);
    // Debug.Log(a);

    movementReference.mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    Vector3 rotation = movementReference.mousePos - transform.position;

    float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

    transform.rotation = Quaternion.Euler(0, 0, rotZ);

    if (!canFire)
    {
      timer += Time.deltaTime;
      if (timer > timeBetweenFiring)
      {
        // canFire = true;
        timer = 0;
      }
    }

    // Shoot(canFire);

    // Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

    // Debug.Log(mousePos);
    if (Input.GetMouseButton(0) && canFire)
    {
      canFire = false;
      ShootBullet();
    }

  }




  void ShootBullet()
  {
    if (currentBullet == null)
    {
      currentBullet = Instantiate(bulletPrefab, weapons.position, Quaternion.identity);
    }


  }

}
