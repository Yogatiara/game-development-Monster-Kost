using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletManager : MonoBehaviour
{
    public Image bulletImage;
    public Shooting shooting;
    // Start is called before the first frame update


    // Update is called once per frame

    void Update()
    {
        if (shooting.canFire)
        {
            bulletImage.color = Color.white;

        }
        else
        {
            bulletImage.color = Color.black;
        }
    }
}
