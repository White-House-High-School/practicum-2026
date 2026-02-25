using UnityEngine;
using System.Collections;

public class Enemytest : MonoBehaviour
{
        public GameObject enemy;
        public bool isGameActive = true;
        [SerializeField] private float waitTime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemy()
    {
        
        while (isGameActive)
        {
        Instantiate(enemy, transform.position, enemy.transform.rotation);
        yield return new WaitForSeconds(waitTime);
        }
        
    }
}