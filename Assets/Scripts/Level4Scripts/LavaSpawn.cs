using UnityEngine;

public class LavaSpawn : MonoBehaviour
{
    public GameObject lavaPrefab; // The prefab of the lava to be spawned.
    public string tag; // The tag of the spawn points attached to this trigger.
    private GameObject spawnPoint;
    private bool canSpawn = true; // Flag to control spawning.
    public bool lavaSpawn = true; // Flag to control lava spawning.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag(tag);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canSpawn)
        {
            // Instantiate a new lava at the spawn point tagged with the specified tag.
            GameObject lava = Instantiate(lavaPrefab, spawnPoint.transform.position, Quaternion.identity);
            canSpawn = false; // Prevents sequential spawns on this trigger (can be reset).
            // Start the lava loop to spawn more lava.
            lavaLoop();
        }
        
    }

    void lavaLoop()
    {
            if (lavaSpawn == false)
            {
                return; // Exit the method if lavaSpawn is false.
            }

            canSpawn = true;
            for (int i = 0; i < 10; i++)
            {
                StartCoroutine(WaitAndSpawn());
                GameObject lava = Instantiate(lavaPrefab, spawnPoint.transform.position, Quaternion.identity);
                if (lavaSpawn == false)
                {
                    Destroy(lava); // Destroy the lava if lavaSpawn is false.
                    canSpawn = false; // Prevents sequential spawns on this trigger (can be reset).
                    break;
                }
            }
    }

    private System.Collections.IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds before spawning the next lava.
    }
}
