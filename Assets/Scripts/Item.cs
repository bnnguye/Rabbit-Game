using UnityEngine;

public abstract class Item : MonoBehaviour {

    public SpriteRenderer sr;

    public abstract void Use();

    public abstract bool Usable();

}