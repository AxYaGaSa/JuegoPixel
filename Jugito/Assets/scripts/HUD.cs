using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI puntosText;

    // Update is called once per frame
    void Update()
    {
        puntosText.text = ":" + gameManager.PuntosTotales.ToString();
    }
}
