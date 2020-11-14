using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject tablero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            tablero.transform.Rotate(0, 0, 1);
        }
        else if (Input.GetKey("right"))
        {
            tablero.transform.Rotate(0, 0, -1);
        }
        else if (Input.GetKey("up"))
        {
            tablero.transform.Rotate(1, 0, 0);
        }
        else if (Input.GetKey("down"))
        {
            tablero.transform.Rotate(-1, 0, 0);
        }
    }
}