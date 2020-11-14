using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBall : MonoBehaviour
{
    [Range(0, 180)]
    public float moveSpeed, rotateSpeed, force;
    private Rigidbody _rigidBody;
    private float verticalInput, horizontalInput;
    public bool usePhysicsEngine;


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Si se usan físicas, AddForce y AddTorque sobre el rigidbody
        // Si no, Translate y Rotate sobre el transform

        MovePlayer();
        KeepPlayerInbounds();
    }

    void MovePlayer()
    {
        if (usePhysicsEngine)
        {
            _rigidBody.AddForce(Vector3.forward * Time.deltaTime * force * verticalInput, ForceMode.Force);
            _rigidBody.AddTorque(Vector3.up * Time.deltaTime * force * horizontalInput, ForceMode.Force);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * horizontalInput);
        }
    }

    void KeepPlayerInbounds()
    {
        //TODO: Refactorizar posición límite a variable
        if (Mathf.Abs(transform.position.x) >= 24 || Mathf.Abs(transform.position.z) >= 24)
        {
            _rigidBody.velocity = Vector3.zero;

            if (transform.position.x > 24)
            {
                transform.position = new Vector3(24, transform.position.y, transform.position.z);
            }

            if (transform.position.x < -24)
            {
                transform.position = new Vector3(-24, transform.position.y, transform.position.z);
            }
            if (transform.position.z > 24)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 24);
            }

            if (transform.position.z < -24)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -24);
            }
        }
    }
}
