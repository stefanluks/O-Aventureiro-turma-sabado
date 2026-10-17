using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia {private set; get;}
    [SerializeField] private int orbesColetadas = 0;
    [SerializeField] private List<Fase> fases;

    [Header("INTERFACE")]
    [SerializeField] private Text orbesText;
    [SerializeField] private GameObject menuOpcoes;
    private int fase_atual = 0;
    int cont = 0;

    void Start()
    {
        // titulo.text = "MEU JOGO!";
        menuOpcoes.SetActive(false);
    }

    void Update()
    {
        orbesText.text = orbesColetadas+"/"+fases[fase_atual].meta;
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

    public void Sair()
    {
        Debug.Log("Encerrando jogo...");
        Application.Quit();
    }

    public void MenuOpcoes()
    {
        menuOpcoes.SetActive(!menuOpcoes.activeSelf);
    }

    public void InciarJogo()
    {
        fase_atual = 1;
        SceneManager.LoadScene("fase1");
    }
}
