using UnityEngine;

public class EnemyWeapon : Weapon {
    public override void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Player>() != null) {
            other.GetComponent<Health>().TakeDamage((int) damage);
        }
    }
}
