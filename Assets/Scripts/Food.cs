using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D gridArea;
    private float spawnTime;
    public float timeBetweenSpawn;

    void Update()
    {
        //RandomizePosition();
        //spawnTime = Time.time;
        if (Time.time > spawnTime)
        {
            RandomizePosition();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
        x = Mathf.Round(x);
        y = Mathf.Round(y);

        transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RandomizePosition();
    }

}
