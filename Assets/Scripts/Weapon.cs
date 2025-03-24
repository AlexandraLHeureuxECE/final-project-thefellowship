using UnityEngine;

public class Weapon : MonoBehaviour {
    public double damage;
    public double knockback;
    public double reach;
    private GameObject player;
    private Transform holdTransform;

    public void setOwner(GameObject player) {
        this.player = player;
        holdTransform = player.transform.Find("Armature").Find("Root_M").Find("Spine1_M").Find("Spine2_M").Find("Chest_M").Find("Scapula_R").Find("Shoulder_R").Find("Elbow_R").Find("Wrist_R");
    }

    void Update() {
        transform.position = holdTransform.position;
        transform.rotation = holdTransform.rotation;
    }
}
