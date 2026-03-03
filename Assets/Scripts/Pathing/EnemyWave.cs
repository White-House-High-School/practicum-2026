using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct ItemEntry // Each ListEntry represents one enemy.
{ 
    public GameObject enemyPrefab; // This is set to an enemy's 3D model. For instance, "Ant_Brown"
    public float delayBeforeSpawn; // The amount of time to wait until this enemy is spawned.
}

[CreateAssetMenu(fileName = "New Wave", menuName = "Enemies/New Wave")]
public class EnemyWave : ScriptableObject // Creates a list full of enemies. Kinda like a pseudo-dictionary.
{
    // This list IS visible in the Inspector
    public List<ItemEntry> enemies = new List<ItemEntry>(); // Makes a list of ItemEntry structs visible and editable in the Inspector.
}
