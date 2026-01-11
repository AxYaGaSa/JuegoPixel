using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Vector2 previousPosition, newPosition;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
    }

    void Update()
    {
        newPosition = transform.position;
        Vector2 velocity = (newPosition - previousPosition) / Time.deltaTime;
        previousPosition = newPosition;

        float velocidad = velocity.magnitude;
        animator.SetFloat("Speed", velocidad);
    }

    public void Atacar()
    {
        animator.SetBool("IsAttacking", true);
    }

    public void TerminarAtaque()
    {
        animator.SetBool("IsAttacking", false);
    }

    public void RecibirGolpe()
    {
        animator.SetTrigger("GotHit");
    }

    public void Morir()
    {
        animator.SetBool("IsDead", true);
    }
}