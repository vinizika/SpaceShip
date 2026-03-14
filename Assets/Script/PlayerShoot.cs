using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform pontoDisparo;

    public float velocidadeBala = 2f;
    public float tempoEntreTiros = 0.3f;

    private float proximoTiro = 0f;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && Time.time >= proximoTiro)
        {
            Disparar();
            proximoTiro = Time.time + tempoEntreTiros;
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, pontoDisparo.position, Quaternion.identity);

        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.right * velocidadeBala;
    }
}