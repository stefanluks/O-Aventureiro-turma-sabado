using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia {private set; get;}
    [SerializeField] private int orbesColetadas = 0;
    [SerializeField] private List<Fase> fases;
    private int fase_atual = 0;
 
    void Awake()
    {
        if(instancia != null && instancia != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ColetarOrbe()
    {
        orbesColetadas++;
    }

    public void TrocarFase()
    {
        if(orbesColetadas == fases[fase_atual].meta)
        {
            fase_atual++;
            SceneManager.LoadScene(fases[fase_atual].nome);
            orbesColetadas = 0;
        }
    }
}
