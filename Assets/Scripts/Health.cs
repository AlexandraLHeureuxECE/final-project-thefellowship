using UnityEngine;

public class Health : MonoBehaviour
{
    protected int maxHP = 100;
    private int curHP;
    
    protected virtual void Start() {
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

    public virtual void TakeDamage(int damage) {
        curHP -= damage;
        
        
        if (curHP <= 0) {
       
            Die();
        }
    }

    public virtual void Die() {
        Destroy(gameObject);
    }
    
    public void AddMaxHP() {
        maxHP += 10;
    }
}