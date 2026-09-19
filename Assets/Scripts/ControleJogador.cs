using UnityEngine;
using UnityEngine.InputSystem;

public class ControleJogador : MonoBehaviour
{
    public int velocidade;
    public Rigidbody2D fisica;
    private Vector2 direcao;
    private Vector2 UltimaDirecao;
    public Animator animador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fisica.linearVelocity = direcao * velocidade;
        animador.SetFloat("eixoX", direcao.x);
        animador.SetFloat("eixoY", direcao.y);
        animador.SetFloat("UltimoX", UltimaDirecao.x);
        animador.SetFloat("UltimoY", UltimaDirecao.y);
        animador.SetBool("correndo", direcao != Vector2.zero);

        if(direcao != Vector2.zero) UltimaDirecao = direcao;
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        direcao = input.ReadValue<Vector2>();
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
    }
}
