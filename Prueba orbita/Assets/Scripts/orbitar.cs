using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitar : MonoBehaviour
{

    private GameObject sol;
    private float radio = 4.6f;
    private float angulo = 0;
    private float z = 0;
    //public Vector3 posinicio, posfin;
    //LineRenderer linea= new GameObject().AddComponent<LineRenderer>();

    void Start()
    {
        // Se localiza el objeto sobre el que se orbitará para tomar su posición
        sol = GameObject.Find("Sol");
        

    }

    void Update()
    {
        // Rotación del planeta alrededor de su estrella
        float pos_x = sol.transform.position.x + Mathf.Cos(angulo * Mathf.Deg2Rad) * radio;
        float pos_y = sol.transform.position.y + Mathf.Sin(angulo * Mathf.Deg2Rad) * radio;
        transform.position = new Vector2(pos_x, pos_y);
        angulo = angulo + 20 * Time.deltaTime;
        
        // Dibuja una línea que va del centro del sol al centro del planeta
        Debug.DrawLine(sol.transform.position, transform.position,Color.white);
        
        // Se simula la rotación del planeta alrededor de su eje
        // z += Time.deltaTime * 20;
        // transform.rotation = Quaternion.Euler(0,0,z);
    }
}
