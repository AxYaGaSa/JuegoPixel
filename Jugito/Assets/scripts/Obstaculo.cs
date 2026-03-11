using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PerderVida();

            other.gameObject.GetComponent<control_movimiento>().AplicarGolpe();
        }
    }
}
