using UnityEngine;

namespace Level4Scripts
{

    public class LavaBehaviour : MonoBehaviour
    {
        Vector3 lavaPos;

        float lavaSpeed = 3f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            lavaPos.z = lavaSpeed;
            transform.position -= lavaPos * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>().TakeDamage(100);
            }

            if (other.CompareTag("LavaEnd"))
            {
                Destroy(gameObject);
            }
        }
    }
}
