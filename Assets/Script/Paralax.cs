using UnityEngine;
//testes
public class Paralax : MonoBehaviour
{
    private float lenght;
    public float parallaxEffect;

    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float velocidade = parallaxEffect * Asteroide.velocidadeGlobal;

        transform.position += Vector3.left * velocidade * Time.deltaTime;

        if (transform.position.x < -lenght)
        {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }
    }
}