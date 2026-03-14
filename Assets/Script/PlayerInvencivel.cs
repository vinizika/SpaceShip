using UnityEngine;
using System.Collections;

public class PlayerInvencivel : MonoBehaviour
{
    private bool invencivel = false;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void AtivarInvencibilidade()
    {
        if (!invencivel)
            StartCoroutine(Invencibilidade());
    }

    IEnumerator Invencibilidade()
    {
        invencivel = true;

        float tempo = 2f;
        float intervalo = 0.2f;

        while (tempo > 0)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(intervalo);
            tempo -= intervalo;
        }

        sprite.enabled = true;
        invencivel = false;
    }

    public bool EstaInvencivel()
    {
        return invencivel;
    }
}