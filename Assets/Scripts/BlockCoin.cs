using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCoin : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.AddCoin();
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        // it is a couroutine which will give animation when the block is hitted.

        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPostion = restingPosition + Vector3.up * 2f;

        yield return Move(restingPosition, animatedPostion);
        yield return Move(animatedPostion, restingPosition);

        Destroy(gameObject); // delete coin after animation
    }

    private IEnumerator Move(Vector3 from, Vector3 to) //Alternative of tweening animation
    {
        float elapsed = 0f;
        float duration = 0.25f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            //lerp is linear interpolation, it gives points between the 2 points.
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
        // it will bring the block to its original position, it is done so , if elapsed time does not match with
        // duration time then the block will not be on its right position. There may be some marginal difference
        // in elapsed time and duration time.
    }
}
