using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform poleBottom;
    public Transform castle;
    public float speed = 6f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(MoveTo(flag, poleBottom.position));
            StartCoroutine(LevelCompleteSequence(collision.transform));
        }
    }

    private IEnumerator LevelCompleteSequence(Transform player)
    {

    }

    private IEnumerator MoveTo(Transform subject, Vector3 destination)
    {
        //while (subject.position != destination)
            //we cannot use this becoz it checks the exact value of position which might be hard to achieve.

        while(Vector3.Distance(subject.position, destination) > 0.125f)
        {

        }
    }
}
