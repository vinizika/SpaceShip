using UnityEngine;

public class Paralax : MonoBehaviour
{

    private float lenght;
    public float parallaxEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * parallaxEffect * Time.deltaTime;
        if (transform.position.x < -lenght){
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }
    }
}
