using UnityEngine;

public class personaje : MonoBehaviour
{
    public float velocidad = 5f;

    public float fuerzaSalto = 10f;
    public float fuerzaRebote = 10f;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;

    private bool estaEnSuelo;
    private bool recibioDano;
    private Rigidbody2D rb;

    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;

        animator.SetFloat("IsRunning", velocidadX * velocidad);

        if (velocidadX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (velocidadX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector3 posicion = transform.position;

        if (!recibioDano)
        {
            transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        estaEnSuelo = hit.collider != null;
        
        if (estaEnSuelo && Input.GetKeyDown(KeyCode.Space) && !recibioDano)
        {
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }

        animator.SetBool("EnSuelo", estaEnSuelo);
        animator.SetBool("recibeDanio", recibioDano);
    }

    public void RecibirDano(Vector2 direccion, int cantidadDano)
    {
        if (!recibioDano)
        {
            recibioDano = true;
            Vector2 rebote = new Vector2(transform.position.x - direccion.x, 0.2f).normalized;
            rb.AddForce(rebote * fuerzaRebote, ForceMode2D.Impulse);
        }
    }

    public void desactivarDano()
    {
        recibioDano = false;
        rb.linearVelocity = Vector2.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }
}
