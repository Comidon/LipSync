using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private SpriteRenderer sr;
    private Collider2D c2;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        c2 = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Collect();
        }
        else if (other.tag == "TrashCan")
        {
            PlayerManager.instance.TakeDamage();
        }
    }

    private void Collect()
    {
        Destroy(gameObject);
    }
}
