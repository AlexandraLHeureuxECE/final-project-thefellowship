using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerLevelProgression : MonoBehaviour
    {
        private int level; 
        private int xp;
        private int xpToNextLevel;
        private int xpForKill;
        private int xpForLevelComplete;
        private Health health;
        private Armour armour;
        
        void Start()
        {
            level = 1;
            xp = 0;
            xpToNextLevel = 100;
            xpForKill = 10;
            health = GetComponent<Health>();
            armour = GetComponent<Armour>();
        }
        
        void Update()
        {
            
        }
        
        void GainXP(int xp)
        {
            this.xp += xp;
            if (this.xp >= xpToNextLevel)
            {
                level++;
                this.xp -= xpToNextLevel;
                xpToNextLevel = 100 * level;
                health.AddMaxHP();
                armour.AddArmourPts();
            }
        }
    }
}