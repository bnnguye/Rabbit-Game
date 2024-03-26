using Unity.VisualScripting;
using UnityEngine;

public class ItemKey : Item {

    DoorLogic door = null;

    void Start() {

        Sprite sprite = Resources.Load<Sprite>("Sprites/Key");

        ReplaceSprite(sprite);
    }
    public override void Use() {
        print("Door opened");
        door.Open();
    }

    public override bool Usable() {
        LocateDoor();
        return door != null;
    }

    void ReplaceSprite(Sprite sprite) {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprite;
    }

    private void LocateDoor() {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        if (gameObject != null) {
            ProximityChecker pc = gameObject.GetComponent<ProximityChecker>();
            foreach (Collider obj in pc.nearbyObjects) {
                if (obj.gameObject.CompareTag("Door")) {
                    print("Found Door");
                    door = obj.gameObject.GetComponent<DoorLogic>();
                    if (door == null) {
                        print("Door object does not contain door.");
                    }
                }
            }
        }
    }
}