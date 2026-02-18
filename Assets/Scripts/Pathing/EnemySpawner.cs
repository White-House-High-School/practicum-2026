using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyBody, new Vector3(0, 0, -20), Quaternion.identity);
    }
}
