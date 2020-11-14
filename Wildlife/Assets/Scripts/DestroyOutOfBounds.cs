using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Comentario
    private float topBound = 30f, lowerBound = -5f;

    void Update()
    {
        if (this.transform.position.z > topBound)
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.z < lowerBound)
        {
            Destroy(this.gameObject);
            Debug.Log("GAME OVER!!!");

            Time.timeScale = 0;
        }
    }
}
