using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_movimiento : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;
    
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private bool mirarDerecha = true;
    private int saltosRestantes;
    private Animator animator; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movimiento();
        Salto();
    }

    void Movimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        if(inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true );
        }
        else
        {
            animator.SetBool("isRunning", false );
        }
        rb.linearVelocity = new Vector2(inputMovimiento * velocidad, rb.linearVelocity.y);
        GestionarOrientacion(inputMovimiento);
    }
    bool EstaEnSuelo()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.1f, capaSuelo);
        return raycast.collider != null;
    }
    void Salto()
    {
        if(EstaEnSuelo())
        {
            saltosRestantes = saltosMaximos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    void GestionarOrientacion(float inputMovimiento)
    {
        if ((mirarDerecha == true && inputMovimiento < 0) || (mirarDerecha == false && inputMovimiento > 0))
        {
            mirarDerecha = !mirarDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
