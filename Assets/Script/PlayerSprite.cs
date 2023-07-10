using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public Color newColor;
    public GameObject playerObject;

    public void ChangePlayerSprite()
    {
        SpriteRenderer playerSpriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        if (playerSpriteRenderer != null)
        {
         
            playerSpriteRenderer.color = newColor;

        }
    }
}