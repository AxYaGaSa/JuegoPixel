using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int PuntosTotales {get { return puntosTotales; } }
    public TextMeshProUGUI puntosText;
    private int puntosTotales;

    private void Update()
    {
        puntosText.text = " : " + puntosTotales.ToString();
    }

    public void AgregarPuntos(int puntos)
    {
        puntosTotales += puntos;
    }
}


