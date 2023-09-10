using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float speedRotate;
    [SerializeField] float speedMove;
    [SerializeField] float slowSpeed = 2f;
    [SerializeField] float boostSpeed = 7f;
    [SerializeField] float boostDuration = 1f;
    float normalSpeed = 4f;

    private bool isBoosted = false;

    void Update()
    {
        RotateCapsule();
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

    private IEnumerator BoostSpeed()
    {
        isBoosted = true;
        speedMove = boostSpeed;

        yield return new WaitForSeconds(boostDuration);

        // Setelah durasi boost selesai, kembalikan kecepatan ke nilai semula
        speedMove = normalSpeed;
        isBoosted = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            speedMove = slowSpeed;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            speedMove = normalSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Booster") && !isBoosted)
        {
            StartCoroutine(BoostSpeed());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Booster"))
        {
            speedMove = normalSpeed;

        }
    }
}
