using Unity.VisualScripting;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Transform respawnLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Player>() != null) {
            other.gameObject.transform.position = respawnLocation.position;
            Debug.Log("HIT!");
        }
    }
}
