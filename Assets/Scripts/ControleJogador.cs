using UnityEngine;
using UnityEngine.InputSystem;

public class ControleJogador : MonoBehaviour
{
    public int velocidade;
    public Rigidbody2D fisica;
    private Vector2 direcao;
    private Vector2 UltimaDirecao;
    public Animator animador;
    private bool atacando = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        if(!atacando){
            fisica.linearVelocity = direcao * velocidade;
        }
        animador.SetFloat("eixoX", direcao.x);
        animador.SetFloat("eixoY", direcao.y);
        animador.SetFloat("UltimoX", UltimaDirecao.x);
        animador.SetFloat("UltimoY", UltimaDirecao.y);
        animador.SetBool("correndo", direcao != Vector2.zero);
        animador.SetBool("atacando", atacando);
        if(direcao != Vector2.zero) UltimaDirecao = direcao;
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        direcao = input.ReadValue<Vector2>();
    }
    public void OnAtack(InputAction.CallbackContext input)
    {
        if(input.performed) atacando = true;
    }

    public void PararAtaque()
    {
        atacando = false;
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Finish")
        {
            GameManager.instancia.TrocarFase();
        }
        if(colisao.gameObject.tag == "orbe")
        {
            Destroy(colisao.gameObject);
            GameManager.instancia.ColetarOrbe();
        }
        if(colisao.gameObject.tag == "Inimigo" && atacando)
        {
            colisao.gameObject.GetComponent<Esqueleto>().Dano();
        }
    }
}
