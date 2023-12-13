using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Use Vector3.forward to move in the world space forward direction.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
