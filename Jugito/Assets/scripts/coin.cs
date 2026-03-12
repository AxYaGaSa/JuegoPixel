using UnityEngine;

public class coin : MonoBehaviour
{
    public int puntoValor = 1;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.AgregarPuntos(puntoValor);
            // Destroy the coin object
            Destroy(this.gameObject);
        }
    }
}
