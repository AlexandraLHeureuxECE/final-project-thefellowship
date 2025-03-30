using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // The prefab of the enemy to be spawned
    private bool canSpawn = true; // Flag to control spawning

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && canSpawn) {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity); // Spawn the enemy
            newEnemy.GetComponent<EnemyFollow>().Player = other.transform;
            canSpawn = false; // Prevent multiple spawns on the same trigger
        }
    }
}
