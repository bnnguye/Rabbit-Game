using Unity.VisualScripting;
using UnityEngine;

public class ItemKey : Item {

    void Start() {

        Sprite sprite = Resources.Load<Sprite>("Sprites/Key");

        ReplaceSprite(sprite);
    }
    public override void Use() {

    }

    public override bool Usable() {
        return true;
    }

    void ReplaceSprite(Sprite sprite) {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprite;
    }
}