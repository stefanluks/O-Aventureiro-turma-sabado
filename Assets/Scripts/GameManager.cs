using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia {private set; get;}
    [SerializeField] private int orbesColetadas = 0;
    private int meta = 3;

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
        if(orbesColetadas == meta)
        {
            SceneManager.LoadScene("fase1");
            orbesColetadas = 0;
        }
    }
}
