using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    private int currentWaypoint = 0;
    private Transform player;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            animator.SetBool("IsAttacking", true);
        }
        else if (distanceToPlayer <= detectionRange)
        {
            animator.SetBool("IsAttacking", false);
            PerseguirJugador();
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            Patrullar();
        }
    }

    void Patrullar()
    {
        Transform target = waypoints[currentWaypoint];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        animator.SetFloat("Speed", speed);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    void PerseguirJugador()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        animator.SetFloat("Speed", speed);
    }
}

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void RecibirDaño(int cantidad)
    {
        currentHealth -= cantidad;

        if (currentHealth > 0)
        {
            animator.SetTrigger("GotHit"); // animación de golpe
        }
        else
        {
            Morir();
        }
    }

    void Morir()
    {
        animator.SetBool("IsDead", true); // activa animación de muerte
        // Opcional: desactivar colisiones y movimiento
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        this.enabled = false; // desactiva el script
    }
}