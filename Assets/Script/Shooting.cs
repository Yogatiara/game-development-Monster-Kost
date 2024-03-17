using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooting : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    public Movement movementReference;

    public Vector2 pointerPosition { get; set; }

    private Vector2 pointerInput;



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();


    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);







        // if (rotZ > -90 && !movementReference.flipRight)
        // {
        //     movementReference.FlipPlayer();
        // }

        // if (rotZ > 90 && movementReference.flipRight)
        // {
        //     movementReference.FlipPlayer();
        // }





    }

    // private Vector2 GetPointerInput()
    // {
    //     Vector3 mousePos = pointerInput.action.ReadValue<Vector2>();
    // }



}
