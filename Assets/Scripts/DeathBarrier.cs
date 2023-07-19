using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            GameManager.Instance.ResetLevel(3f);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
