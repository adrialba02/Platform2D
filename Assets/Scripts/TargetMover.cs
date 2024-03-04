using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position, 
            target.position + offset,
            speed * Time.deltaTime);
    }
}
