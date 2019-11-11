using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float playerYPos = 0;
    private float hp = 100f;

    //I am an artist, a performance artist
    //fafafafafafafafa
    private IPerformanceArtist van_sama;

    private void Start()
    {
        van_sama = GetComponentInChildren<YourLipsAreMoving>();
    }

    private void Update()
    {
        /**
        playerYPos = Input.GetAxis("Vertical") * 2;
        transform.position = new Vector3(0, playerYPos, 0);
        */
        playerYPos = van_sama.GetLipsPosition().y;
    }

    private void FixedUpdate()
    {
        Debug.Log(hp);
        if (Mathf.Abs(DrawWave.instance.GetOriginYPos() - playerYPos) > 1.4)
        {
            hp -= 2;
        }

        if (hp < 99.8)
        {
            hp += 0.2f;
        }
        else
        {
            hp = 100;
        }
    }
}
