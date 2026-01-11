using UnityEngine;

public class coin : MonoBehaviour
{
    public int puntoValor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AgregarPuntos(puntoValor);
            // Destroy the coin object
            Destroy(this.gameObject);
        }
    }
}
