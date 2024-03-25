using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Movement movement;

    ProximityChecker pc;

    ItemManager im;

    void Start() {
        movement = GetComponent<Movement>();
        pc = GetComponent<ProximityChecker>();
        im = ItemManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            movement.Move(Controls.LEFT);
        }
        else if (Input.GetKey(KeyCode.D)) {
            movement.Move(Controls.RIGHT);
        }

        if (Input.GetKey(KeyCode.W)) {
            movement.Move(Controls.UP);
        }
        else if (Input.GetKey(KeyCode.S)) {
            movement.Move(Controls.DOWN);
        }

        if (Input.GetKey(KeyCode.Space)) {
            movement.Move(Controls.RUN);
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            Collider[] nearbyObjects = pc.nearbyObjects;
            if (nearbyObjects != null) {
                foreach (Collider nearbyObject in nearbyObjects) {
                    if (LayerMask.LayerToName(nearbyObject.gameObject.layer) == "Item") {
                        Item item = nearbyObject.GetComponent<Item>();
                        if (item == null) {
                            print("Object found in item layer that is not an item. Item: " + item.name);
                        }
                        else {
                            print("Item added: " + item.name);
                            im.AddItem(item);
                        }
                    }
                }
            }
        }
    }
}
