using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;

public class control_movimiento : MonoBehaviour { 
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
        rb.velocity = new Vector2(inputMovimiento * velocidad, rb.velocity.y);
        GestionarOrientacion(inputMovimiento);
    }
    bool EstaEnSuelo()
    {
        // Origen: justo en los pies del personaje
        Vector2 origen = new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.min.y);
    
        // Raycast hacia abajo desde los pies
        RaycastHit2D raycast = Physics2D.Raycast(origen, Vector2.down, 0.2f, capaSuelo);
    
        return raycast.collider != null;
    }

    void Salto()
    {
        // Reinicia saltos SOLO si está en suelo y la velocidad vertical es casi cero
        if (EstaEnSuelo() && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            saltosRestantes = saltosMaximos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            rb.velocity = new Vector2(rb.velocity.x, 0f); // reset vertical
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