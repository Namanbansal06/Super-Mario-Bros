using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;

    //add variables for sprite
    public Sprite idle;
    public Sprite jump;
    public AnimatedSprite run;
    public Sprite slide;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void LateUpdate()
    {
        run.enabled = playerMovement.running;
        if (playerMovement.jumping)
        {
            spriteRenderer.sprite = jump;
        }
        else if (playerMovement.sliding)
        {
            spriteRenderer.sprite = slide;
        }
        else if(!playerMovement.running)
        {
            spriteRenderer.sprite = idle;
        }
    }
}
