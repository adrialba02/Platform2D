using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public GameObject objetoMovil;

    public Transform StartPoint;
    public Transform EndPoint;

    public float speed;

    private Vector3 moverHacia;
    void Start()
    {
        moverHacia = EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        objetoMovil.transform.position = Vector3.MoveTowards(objetoMovil.transform.position, moverHacia, speed * Time.deltaTime);
        
        if(objetoMovil.transform.position == EndPoint.position)
        {
            moverHacia = StartPoint.position;
        }

        if (objetoMovil.transform.position == StartPoint.position)
        {
            moverHacia = EndPoint.position;
        }
    }
}
