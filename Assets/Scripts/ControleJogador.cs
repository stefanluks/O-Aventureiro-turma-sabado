using UnityEngine;
using UnityEngine.InputSystem;

public class ControleJogador : MonoBehaviour
{
    public int velocidade;
    public Rigidbody2D fisica;
    private Vector2 direcao;
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
        animador.SetBool("correndo", direcao != Vector2.zero);
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        direcao = input.ReadValue<Vector2>();
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Finish")
        {
            Debug.Log("Fase concluida");
        }
        if(colisao.gameObject.tag == "orbe")
        {
            Destroy(colisao.gameObject);
        }
    }
}
