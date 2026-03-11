using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public float velocidad ;
    public float fuerzaSalto;
    public int saltosMaximos ;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private int saltosRestantes;
    private Animator animator;
    private Vector2 movimientoInput;
    private bool saltarInput;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        saltosRestantes = saltosMaximos;
    }

    void Update() {
        Movimiento();
        Salto();
    }

    void Movimiento()
    {
        if (animator != null) {
            animator.SetBool("isRunning", movimientoInput.x != 0f);
        }
        rb.velocity = new Vector2(movimientoInput.x * velocidad, rb.velocity.y); // Corregido: velocity, no linearVelocity
        GestionarOrientacion(movimientoInput.x);
    }

    void Salto()
    {
        if (EstaEnSuelo() && Mathf.Abs(rb.velocity.y) < 0.01f) { // Corregido: velocity
            saltosRestantes = saltosMaximos;
        }

        if (saltarInput && saltosRestantes > 0) {
            saltosRestantes--;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            if (animator != null) animator.SetTrigger("jumpTrigger");
            saltarInput = false;
        }
    }

    bool EstaEnSuelo() {
        Vector2 origen = new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.min.y);
        RaycastHit2D raycast = Physics2D.Raycast(origen, Vector2.down, 0.2f, capaSuelo);
        return raycast.collider != null;
    }

    void GestionarOrientacion(float inputMovimiento) {
        bool mirarDerecha = transform.localScale.x > 0;
        if ((mirarDerecha && inputMovimiento < 0) || (!mirarDerecha && inputMovimiento > 0)) {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
