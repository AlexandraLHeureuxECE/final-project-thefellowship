using UnityEngine;

namespace Level4Scripts
{
    public class SkullBehaviour : MonoBehaviour
    {
        public int skullsCollected = 0;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                    Destroy(gameObject);
                    skullsCollected++;
            }
        }
    }
}