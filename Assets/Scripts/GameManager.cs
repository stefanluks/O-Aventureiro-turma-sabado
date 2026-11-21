using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia {private set; get;}
    [SerializeField] private int orbesColetadas = 0;
    [SerializeField] private List<Fase> fases;
    [SerializeField] private GameObject esqueletoPrefab;

    [Header("INTERFACE")]
    [SerializeField] private Text orbesText;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuOpcoes;
    [SerializeField] private GameObject fimDeJogo;

    [Header("Audios")]
    [SerializeField] private AudioSource trilha;
    [SerializeField] private Slider volumeMusica;
    [SerializeField] private AudioSource somOrbe;
    [SerializeField] private Slider volumeSFX;

    public int fase_atual = 0;
    int cont = 0;

    void Start()
    {
        // titulo.text = "MEU JOGO!";
        menuOpcoes.SetActive(false);
    }

    void Update()
    {
        if(fase_atual < fases.Count)
        {
            orbesText.text = orbesColetadas+"/"+fases[fase_atual].meta;
        }
    }

    public void VolumeMusica()
    {
        trilha.volume = volumeMusica.value;
    }
    public void VolumeSFX()
    {
        somOrbe.volume = volumeSFX.value;
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
        somOrbe.Play();
    }

    public void TrocarFase()
    {
        if(orbesColetadas == fases[fase_atual].meta)
        {
            fase_atual++;
            if(fase_atual >= fases.Count)
            {
                fimDeJogo.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(fases[fase_atual].nome);
                orbesColetadas = 0;
                Invoke("ColocarEsqueletos", 1f);
            }
        }
    }

    public void VoltarParaMenu()
    {
        menu.SetActive(true);
        menuOpcoes.SetActive(false);
        fimDeJogo.SetActive(false);
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
       menu.SetActive(false);
       menuOpcoes.SetActive(false);
       ColocarEsqueletos();
    }

    void ColocarEsqueletos()
    {
        int quantidade = fases[fase_atual].meta;
        for(int i=0; i < quantidade; i++)
        {
            float x = Random.Range(-6.69f, 6.69f);
            float y = Random.Range(-3.57f, 3.57f);
            Instantiate(esqueletoPrefab, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
