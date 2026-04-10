using UnityEngine;

public class EnemyManager: MonoBehaviour

{
    int waveIndex; // Keeps track of which enemy in the wave is supposed to be spawned
    float timer; // The amount of time between spawns. Each enemy has its own individual timer attached to it.

    public EnemyWave wave; // An instance of the EnemyWave ScriptableObject. Contains one wave of enemies. Each enemy has a prefab of its model and a timer.

    [SerializeField] private Transform antHill;
    [SerializeField] private Transform ground;

    void Start()
    {
        waveIndex = 0; 
        timer = wave.enemies[waveIndex].delayBeforeSpawn; // Sets the timer to the first enemy's timer.

        SpawnNextEnemy(); // Spawns the first enemy.
        
    }

    void Update()
    {
        timer -= Time.deltaTime; // Subtracts the amount of time since the last frame from the timer. This occurs every frame.
        if (timer <= 0 && !IsLastEnemy()) // If the timer gets to 0s and we are not on the last enemy, spawn an enemy, move to the next enemy, and reset the timer.
        {
            SpawnNextEnemy(); // Spawn the next enemy in the list  
            waveIndex++; // Move onto the next, unspawned enemy
            timer = wave.enemies[waveIndex].delayBeforeSpawn; // Reset the timer to whatever the next, unspawned enemy in the list is.
        }
        
    }

    bool IsLastEnemy() // Checks if we have spawned all enemies
    {
        if (waveIndex == wave.enemies.Count - 1) // If we are on the last enemy, return true. Otherwise, return false.
        {
            return true;
        }
        return false;
    }

    void SpawnNextEnemy() // Spawns the enemy that we are on right now.
    {
        // Sets the ant's spawn point to the grass.
        float spawnYCoord = antHill.position.y + (-1 *(antHill.position.y)); // Yes, VSCode. I. Know. That. The Parentheses. Are. Not. Necessary.
        Vector3 spawnPoint = new Vector3(antHill.position.x, spawnYCoord, antHill.position.z);
        
        GameObject prefab = wave.enemies[waveIndex].enemyPrefab;

        Instantiate(prefab, spawnPoint, prefab.transform.rotation); // Instantiates an enemy with the enemy model prefab at the ant hill
                                                                                                     // (hardcoded for now)
    }

}

