using UnityEngine;

public class Health : MonoBehaviour {
    private int maxHP;
    private int curHP;
    
    void Start() {
        maxHP = 100;
        curHP = maxHP;
    }
    
    void Update() {
        if (curHP < 0) {
            Die();
        }
    }

    void Heal(int hp) {
        curHP += hp;

        if (curHP > maxHP) {
            curHP = maxHP;
        }
    }

    void TakeDamage(int hp) {
        curHP -= hp;
    }

    void Die() {
        
    }
    
    public void AddMaxHP() {
        maxHP += 10;
    }
}