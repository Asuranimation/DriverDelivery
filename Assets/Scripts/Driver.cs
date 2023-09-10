using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    
    [SerializeField] float speedRotate;
    [SerializeField] float speedMove;
    [SerializeField] float slowSpeed;
    [SerializeField] float boostSpeed = 7f;
   
    void Update()
    {
        RotateCapsule();
        slowSpeed = 4f;
    }

    private void FixedUpdate()
    {
        MoveCapsule();
    }

    void RotateCapsule()
    {
        float steerAmount = Input.GetAxis("Horizontal") * speedRotate;
        transform.Rotate(new Vector3 (0,0,-steerAmount));
    }

    void MoveCapsule()
    {
        float move = Input.GetAxis("Vertical") * speedMove * Time.deltaTime;
        float backwardSpeedFactor = 0.5f;

        if (move < 0) 
        {
            move *= speedMove * backwardSpeedFactor ;
        }
        else 
        {
            move *= speedMove ;
        }

        transform.Translate(new Vector3(0, move, 0));
    }
}
