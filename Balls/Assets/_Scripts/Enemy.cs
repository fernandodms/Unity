using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody _rigidbody;
    public float moveForce = 0.3f;
    private GameObject player;
    private Vector3 lookDirection;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        // Localizamos al jugador para movernos hacia él
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // La dirección en que se debe mover el enemigo se obtiene con la diferencia entre
        // la posición del objetivo y la del origen
        // Se normaliza para que el vector siempre tenga valor 1 y luego multiplicar por la fuerza
        lookDirection = (player.transform.position - this.transform.position).normalized;
        _rigidbody.AddForce(lookDirection * moveForce);


        // Para destruir el objeto enemigo, lo destruímos cuando su coordenada y es negativa,
        // lo que significa que ha caído por el borde.
        // Otra forma es crear una caja invisible con un collider que esté bajo el nivel del suelo
        // y detectar cuando el enemigo colisiona con ella
        if (this.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
