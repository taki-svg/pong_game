using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player_b_m : MonoBehaviour
{
    private Touch touch;
    private float sm;
    void Start()
    {
        sm = 0.005f;
        //-2.37 x move to 2.37
      
        
    }
    private void FixedUpdate()
    {
        if (Input.touchCount > 0) // greater then zero means one or more fingers in touch with screen
        {
            touch = Input.GetTouch(0); // first touch is set to 0 if two fingers are in touch then it would be 0,1.

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * sm, transform.position.y,
                    transform.position.z + touch.deltaPosition.y * sm);
            }
        }

    }
}
