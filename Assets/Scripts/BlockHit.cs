using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    public int maxHit = -1;
    public Sprite emptyBlock;

    private bool animating;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && collision.gameObject.CompareTag("Player"))
        {
            if(collision.transform.DotProductTest(transform, Vector2.up)){
                //collision.transform is mario and transform in dottest is block.

                Hit();
            }
        }
    }

    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        maxHit--;
        if(maxHit == 0)
        {
            spriteRenderer.sprite = emptyBlock;
        }

        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        // it is a couroutine which will give animation when the block is hitted.

        animating = true;
        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPostion = restingPosition + Vector3.up * 0.5f;

        yield return Move(restingPosition, animatedPostion);
        yield return Move(animatedPostion, restingPosition);
        animating = false;
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duration = 0.125f;

        while(elapsed < duration)
        {
            float t = elapsed / duration;
        }
    }
}