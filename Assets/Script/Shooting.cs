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

  void Start()
  {
    mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
  }

  void Update()
  {
    movementReference.mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    Vector3 rotation = movementReference.mousePos - transform.position;

    float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

    transform.rotation = Quaternion.Euler(0, 0, rotZ);

    if (!canFire)
    {
      timer += Time.deltaTime;
      if (timer > timeBetweenFiring)
      {
        canFire = true;
        timer = 0;
      }
    }

    if (Input.GetMouseButton(0) && canFire)
    {
      canFire = false;
      ShootBullet();
      // currentBullet = Instantiate(bulletPrefab, weapons.position, Quaternion.identity);
    }
  }

  void ShootBullet()
  {
    if (currentBullet == null)
    {
      currentBullet = Instantiate(bulletPrefab, weapons.position, Quaternion.identity);
    }
    // if (canFire)
    // {


    // }
    // else if (!canFire)
    // {
    //     if (currentBullet)
    //     {
    //         currentBullet = Instantiate(bulletPrefab, weapons.position, Quaternion.identity);
    //     }
    // }

  }

  // Metode ini dapat dipanggil dari skrip peluru ketika peluru dihancurkan atau mencapai tujuan
  // public void BulletDestroyed()
  // {
  //     currentBullet = null;
  // }
}
