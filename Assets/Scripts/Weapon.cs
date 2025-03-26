using System;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public float damage = 25;
    public double knockback;
    public double reach;
    private GameObject player;
    private Transform holdTransform;
    
    private HitMarker marker;
    
    private float hitCooldown = 0.5f;
    private float hitCooldownTime = -999f;

    public void setOwner(GameObject player) {
        this.player = player; // is attached to palyer
        holdTransform = player.transform.Find("Armature").Find("Root_M").Find("Spine1_M").Find("Spine2_M").Find("Chest_M").Find("Scapula_R").Find("Shoulder_R").Find("Elbow_R").Find("Wrist_R");
    }

    private void Start()
    {
        marker = FindObjectOfType<HitMarker>();
    }

    void Update() {
        transform.position = holdTransform.position;
        transform.rotation = holdTransform.rotation;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Player")) return; //So it doesnt hit player

        if(Time.time - hitCooldownTime < hitCooldown) return; //Cooldown

        if (other.CompareTag("Enemy"))
        {
            if (marker != null)
            {
                marker.ShowHitMarker();
            }
            
            EnemyHealth health = other.GetComponentInParent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage((int)damage); //Damage the enemy
                hitCooldownTime = Time.time;
            }
        }
    }
}
