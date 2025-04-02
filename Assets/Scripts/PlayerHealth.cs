using UnityEngine;

public class PlayerHealth : Health {
    public Transform respawnLocation;

    public override void Die() {
        gameObject.transform.position = respawnLocation.position;

        // Reset all spawn triggers.
        GameObject[] spawnTriggers = GameObject.FindGameObjectsWithTag("SpawnTrigger");

        foreach (GameObject spawnTrigger in spawnTriggers) {
            spawnTrigger.GetComponent<EnemySpawn>().ResetSpawnTrigger();
        }

        // Destroy all existing enemy GameObjects.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }

        ResetHealth();
    }
}
