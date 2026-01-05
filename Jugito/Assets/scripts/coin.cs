using UnityEngine;

public class coin : MonoBehaviour
{
<<<<<<< HEAD
    public int valor = 1;
    public GameManager gameManager;

    private void OnTriggerEnt2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarPuntos(valor);
=======
    public int puntoValor = 1;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.AgregarPuntos(puntoValor);
            // Destroy the coin object
>>>>>>> fix-monedas
            Destroy(this.gameObject);
        }
    }
}
