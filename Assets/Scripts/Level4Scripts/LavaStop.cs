using UnityEngine;

public class LavaStop : MonoBehaviour
{
    private LavaSpawn lavaSpawn;
    private GameObject[] lavaPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lavaSpawn = FindObjectOfType<LavaSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        lavaPrefabs = GameObject.FindGameObjectsWithTag("Lava");
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lavaSpawn.lavaSpawn = false;
            foreach (var lava in lavaPrefabs)
            {
                Destroy(lava.gameObject);
            }
        }
    }
}
