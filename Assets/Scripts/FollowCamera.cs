using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject playerPosition;
    [SerializeField] Vector3 offset;
    
    void Update()
    {
        transform.position = playerPosition.transform.position + offset ;
    }
}
