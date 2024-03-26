using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public bool hasOpened = false;

    SpriteRenderer sr;
    Sprite closedSprite;
    Sprite openSprite;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Load sprites and store them for later use
        closedSprite = Resources.Load<Sprite>("Sprites/Closed Door");
        openSprite = Resources.Load<Sprite>("Sprites/Open Door");

        // Check if sprites are loaded successfully
        if (closedSprite == null || openSprite == null)
        {
            Debug.LogError("Failed to load sprites. Make sure the resource paths are correct.");
        }
    }

    void Update()
    {
        // Toggle between open and closed states
        if (hasOpened)
        {
            Open();
            if (openSprite != null) {
                sr.sprite = openSprite;
            }
        else {
            Debug.LogWarning("Open sprite is null.");
        }
        }
        else
        {
            Close();
            if (closedSprite != null) {
                sr.sprite = closedSprite;
            }
            else
            {
                Debug.LogWarning("Closed sprite is null.");
            }
        }
    }

    public void Open()
    {
        hasOpened = true;
    }

    public void Close()
    {
        hasOpened = false;
    }
}
