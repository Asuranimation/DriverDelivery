using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float speedRotate;
    [SerializeField] float speedMove;
    void Start()
    {
    }

    void Update()
    {
        MoveCapsule();
        RotateCapsule();
    }

    void RotateCapsule()
    {
        float steerAmount = Input.GetAxis("Horizontal") * speedRotate;
        transform.Rotate(new Vector3 (0,0,-steerAmount));
    }

    void MoveCapsule()
    {
        float move = Input.GetAxis("Vertical") * speedMove * Time.deltaTime;
        transform.Translate(new Vector3 (0,move,0));
    }
}
