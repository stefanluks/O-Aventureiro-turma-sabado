using UnityEngine;
using UnityEngine.InputSystem;

public class ControleJogador : MonoBehaviour
{
    public int velocidade;
    public Rigidbody2D fisica;
    private Vector2 direcao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fisica.linearVelocity = direcao * velocidade;
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
    }
}
