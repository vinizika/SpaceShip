using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 3f;

    public float limiteXMin = -4.13f;
    public float limiteXMax = 4.13f;
    public float limiteYMin = -2.33f;
    public float limiteYMax = 2.33f;

    private Rigidbody2D rb;
    private Vector2 movimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimento = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            movimento.y = 1;

        if (Keyboard.current.sKey.isPressed)
            movimento.y = -1;

        if (Keyboard.current.aKey.isPressed)
            movimento.x = -1;

        if (Keyboard.current.dKey.isPressed)
            movimento.x = 1;
    }

    void FixedUpdate()
    {
        Vector2 novaPosicao = rb.position + movimento * velocidade * Time.fixedDeltaTime;

        novaPosicao.x = Mathf.Clamp(novaPosicao.x, limiteXMin, limiteXMax);
        novaPosicao.y = Mathf.Clamp(novaPosicao.y, limiteYMin, limiteYMax);

        rb.MovePosition(novaPosicao);
    }
}