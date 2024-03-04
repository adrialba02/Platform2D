using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways] 
public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;

    [Header("Deteccion de suelo")]
    [Min(0f)] //limita poder cambiar los valores a negativo
    //[Range(0f, 2f)] para hacer un slider

    public float raycastDistance;
    public bool grounded;
    public LayerMask layerMask;

    public Vector2[] points;

    public Rigidbody2D rb;
    public float velocidadSalto;

    //public List<Vector2> points;

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0, 0);

        grounded = false;
        foreach (Vector2 p in points)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)p, -Vector2.up, raycastDistance, layerMask);
            Debug.DrawRay(transform.position +(Vector3)p, - Vector2.up * raycastDistance, Color.red);
            Debug.DrawRay(transform.position +(Vector3)p, - Vector2.up * hit.distance, Color.green);

            if(hit.collider != null)
            {
                grounded = true;

                if (hit.collider.CompareTag("PlataformaMovil") && grounded)
                {
                    transform.parent = hit.collider.transform; 
                }
                else
                {
                    transform.parent = null;
                }
            }
        }        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(grounded == true)
            {
                rb.AddForce(new Vector2(0, velocidadSalto));
            }
        }
    }
}
