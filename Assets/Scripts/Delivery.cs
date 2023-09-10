using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] bool hasPackage = false;
    [SerializeField] float delay = 1f;

    SpriteRenderer spriteRenderer;

    [SerializeField] Color32 hasPackageColor;
    [SerializeField] Color32 noPackageColor;
    void Start()
    {
        hasPackage = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("PickUp");
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject,delay);
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Customer");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
