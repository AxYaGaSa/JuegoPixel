using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HUD hud;
    public int PuntosTotales { get; private set; }
    private int vidasRestantes = 3;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarPuntos(int puntos)
    {
        PuntosTotales += puntos;
        hud.ActualizarPuntos(PuntosTotales);
    }

    public void PerderVida()
    {
        vidasRestantes -= 1;

        if (vidasRestantes == 0)
        {
            SceneManager.LoadScene(0);
        }

        hud.DesactivarVida(vidasRestantes);
    }

    public bool RecuperarVida()
    {
        if (vidasRestantes == 3) 
        {
            return false;
        }
        hud.ActivarVida(vidasRestantes);
        vidasRestantes += 1;
        return true;
    }
}


