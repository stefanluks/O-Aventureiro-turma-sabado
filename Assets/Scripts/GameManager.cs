using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia {private set; get;}
    [SerializeField] private int orbesColetadas = 0;
    [SerializeField] private Text titulo;
    [SerializeField] private List<Fase> fases;
    private int fase_atual = 0;
    int cont = 0;

    void Start()
    {
        // titulo.text = "MEU JOGO!";
    }
 
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

    public void Demonstracao()
    {
        cont++;
        Debug.Log("TESTE: "+cont);
        titulo.text = ""+cont;
        titulo.gameObject.SetActive(cont % 2 == 0);
    }
}
