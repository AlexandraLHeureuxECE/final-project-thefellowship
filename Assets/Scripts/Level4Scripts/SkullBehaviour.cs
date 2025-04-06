using UnityEngine;

namespace Level4Scripts
{
    public class SkullBehaviour : MonoBehaviour
    {
        public int skullsCollected = 0;
        public TMPro.TMP_Text skullsText;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Skull")
            {
                    Destroy(collision.gameObject);
                    skullsCollected++;
                    skullsText.text = "Skulls Collected: " + skullsCollected;
            }
            if (collision.gameObject.tag == "LevelEnd")
            {
                if (skullsCollected == 4)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}