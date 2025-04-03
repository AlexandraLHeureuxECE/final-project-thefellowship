using UnityEngine;

namespace Level4Scripts
{
    public class LevelComplete : MonoBehaviour
    {
        public SkullBehaviour skullBehaviour;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (skullBehaviour.skullsCollected == 4)
                {
                    
                }
            }
        }
        
    }
}
