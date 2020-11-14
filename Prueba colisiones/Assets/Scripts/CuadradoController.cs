using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadradoController : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right")){
            gameObject.transform.position= new Vector3(gameObject.transform.position.x+10*Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if(Input.GetKey("left")){
            gameObject.transform.position= new Vector3(gameObject.transform.position.x-10*Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if(Input.GetKey("down")){
            gameObject.transform.position= new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-10*Time.deltaTime, gameObject.transform.position.z);
        }
        if(Input.GetKey("up")){
            gameObject.transform.position= new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+10*Time.deltaTime, gameObject.transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemy"){
            {
                Debug.Log("Ha chocado");
                Destroy(gameObject);
            }
        }
    }
}
