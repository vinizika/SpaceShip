using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int pontos = 0;
    public int vidas = 3;

    public TextMeshProUGUI textoPontos;
    public TextMeshProUGUI textoVidas;

    public GameObject player;
    public Vector2 respawnPos = new Vector2(-4.08f, 0f);

    private int proximaMeta = 100;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AtualizarUI();
    }

    public void AdicionarPontos(int valor)
    {
        pontos += valor;
        AtualizarUI();

        if (pontos >= proximaMeta)
        {
            StartCoroutine(AsteroidesLentos());
            proximaMeta += 100;
        }
    }

    public void PerderVida()
    {
        vidas--;
        AtualizarUI();

        if (vidas <= 0)
        {
            GameOver();
        }
        else
        {
            StartCoroutine(RespawnPlayer());
        }
    }

    IEnumerator RespawnPlayer()
    {
        player.transform.position = respawnPos;

        PlayerInvencivel inv = player.GetComponent<PlayerInvencivel>();
        inv.AtivarInvencibilidade();

        yield return null;
    }

    IEnumerator AsteroidesLentos()
    {
        Asteroide.velocidadeGlobal *= 0.5f;

        yield return new WaitForSeconds(5f);

        Asteroide.velocidadeGlobal *= 2f;
    }

    void AtualizarUI()
    {
        if (textoPontos != null)
            textoPontos.text = "Pontos: " + pontos;

        if (textoVidas != null)
            textoVidas.text = "Vidas: " + vidas;
    }

    void GameOver()
    {
        Debug.Log("Game Over");
    }
}