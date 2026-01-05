using UnityEngine;
<<<<<<< HEAD

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SumarPuntos(int SumaPundos)
    {
        puntosTotales += SumaPundos;
    }
}
=======
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


>>>>>>> fix-monedas
