using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public double health;
    public Weapon weapon;
    public Armour armour;
    

    public void TakeDamage(double dmg) {
        health -= dmg;
        if (health <= 0) Destroy(gameObject);
    }
}
