using UnityEngine;

public class SpawnerAsteroide : MonoBehaviour
{
    public GameObject asteroidePrefab;

    public float tempoSpawn = 2f;

    public float yMin = -2.10f;
    public float yMax = 2.10f;

    public float xSpawn = 10f;

    void Start()
    {
        InvokeRepeating("SpawnAsteroide", 1f, tempoSpawn);
    }

    void SpawnAsteroide()
    {
        float posY = Random.Range(yMin, yMax);

        Vector3 posicao = new Vector3(xSpawn, posY, 0);

        Quaternion rotacao = Quaternion.Euler(0, 0, 330);

        GameObject asteroide = Instantiate(asteroidePrefab, posicao, Quaternion.identity);

        float tamanho = Random.Range(0.1f, 0.2f);

        asteroide.transform.localScale = new Vector3(tamanho, tamanho, 1);
    }
}