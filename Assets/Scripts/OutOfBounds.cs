using Unity.VisualScripting;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Transform respawnLocation; // The location to return the Player to.

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Player>() != null) {
            other.gameObject.transform.position = respawnLocation.position;

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
        }
    }
}
