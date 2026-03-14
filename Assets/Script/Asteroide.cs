using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public static float velocidadeGlobal = 3f;

    void Update()
    {
        transform.Translate(Vector2.left * velocidadeGlobal * Time.deltaTime);

        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            GameManager.instance.AdicionarPontos(10);

            Destroy(other.gameObject); // destrói bala
            Destroy(gameObject);       // destrói asteroide
        }

        if (other.CompareTag("Player"))
        {
            PlayerInvencivel inv = other.GetComponent<PlayerInvencivel>();

            if (!inv.EstaInvencivel())
            {
                GameManager.instance.PerderVida();
                Destroy(gameObject);
            }
        }
    }
}