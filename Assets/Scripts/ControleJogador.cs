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
        Debug.Log("Hello, world!");
    }

    // Update is called once per frame
    void Update()
    {
        fisica.linearVelocity = new Vector2(direcao.x * velocidade, 0);
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        direcao = input.ReadValue<Vector2>();
    }
}
