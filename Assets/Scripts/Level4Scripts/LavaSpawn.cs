using System.Collections;
using UnityEngine;

public class LavaSpawn : MonoBehaviour
{
    public GameObject lavaPrefab; // The prefab of the lava to be spawned.
    public string tag; // The tag of the spawn points attached to this trigger.
    private GameObject spawnPoint;
    private bool canSpawn = true; // Flag to control spawning.
    public bool lavaSpawn = false; // Flag to control lava spawning.


    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag(tag);
    }

    
    void Update()
    {
     
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start the lava spawn when the player enters the trigger zone
            canSpawn = false; // Prevent further triggering of spawn until reset
            lavaSpawn = true; // Begin spawning lava
            StartCoroutine(SpawnLavaLoop()); // Start the lava spawning loop
        }
    }

    private IEnumerator SpawnLavaLoop()
    {
        for (int i = 0; i < 20; i++) // Spawn 10 lava objects
        {
            if (!lavaSpawn) // If lavaSpawn is set to false, stop spawning
            {
                yield break; // Exit the loop if lavaSpawn is false
            }

            // Instantiate a new lava at the spawn point
            Instantiate(lavaPrefab, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }

        // After the loop ends, reset the spawn logic
        canSpawn = true; // Allow re-triggering for future lava spawns
        lavaSpawn = false; // Stop lava spawning after the loop completes
    }
}
