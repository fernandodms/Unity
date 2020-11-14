using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed=60;
    private float horizontalInput;

    // La cámara está puesta como hija del objeto focal point, por lo cual, aunque se rote
    // siempre va a enfocar a ese objeto

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
