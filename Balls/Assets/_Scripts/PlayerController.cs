using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigidbody;
    public float moveForce = 2;
    private float forwardInput;

    // Como la cámara rota con el focal point, la bola se debe mover hacia delante con respecto
    // a la dirección hacia alante del focal point. Se hace referencia al focal point para
    // poder coger su orientación y mover la bola en la dirección correcta

    public GameObject focalPoint;

    public bool hasPowerUp;
    public float powerUpForce;
    public float powerUpTime = 7;
    public GameObject[] powerUpIndicators;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * forwardInput, ForceMode.Force);

        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = transform.position + 0.5f * Vector3.down;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }

        if (other.gameObject.name.CompareTo("KillZone") == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Prototype 4");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerUp && collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // El vector no hace falta normalizarlo, ya que, al chocar, la distancia siempre
            // es la misma, ya que se están tocando. La normalización se hace cuando la
            // distancia puede ser distinta cada vez. Si no, no es necesaria, aunque se puede
            // especificar si se quiere

            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
            //Debug.Log("El jugador ha colisionado contra " + collision.gameObject +" y tiene el power up a " + hasPowerUp);
        }
    }

    IEnumerator PowerUpCountdown()
    {
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime / powerUpIndicators.Length);
            indicator.gameObject.SetActive(false);
        }
        hasPowerUp = false;
    }
}