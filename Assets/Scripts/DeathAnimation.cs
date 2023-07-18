using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public Sprite deadSprite;
    public SpriteRenderer spriteRenderer;

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        UpdateSprite();
        DisablePhysics();
        Animate();
    }

    private IEnumerator Animate()
    {

    }

    private void UpdateSprite()
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sortingOrder = 10; //we want that the death sprite should be on the top of all the sprites.

        if(deadSprite != null)
        spriteRenderer.sprite = deadSprite;
    }

    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        GetComponent<Rigidbody2D>().isKinematic = true;

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        EntityMovement entityMovement = GetComponent<EntityMovement>();

        if(playerMovement != null)
        {
            playerMovement.enabled = false;
        }
        if(entityMovement != null)
        {
            entityMovement.enabled = false;
        }
    }
}
