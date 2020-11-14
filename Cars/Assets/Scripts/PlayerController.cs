using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 20), Tooltip("Controla la velocidad lineal máxima del coche"), SerializeField]
    // Serialized hace que, aunque sea privada, la variable se vea en el inspector
    private float speed = 20f;

    [Range(0, 90), Tooltip("Controla la velocidad de giro máxima del coche"), SerializeField]
    private float turnSpeed = 30f;

    private float horizontalInput, verticalInput;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(speed * Time.deltaTime * Vector3.forward * verticalInput);
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalInput);

    }
}
