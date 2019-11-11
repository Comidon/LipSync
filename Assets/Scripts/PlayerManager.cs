using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float thatsGood = 0.149f;

    private float damage = 0.5f;

    private float recover = 0.2f;

    private float playerYPos = 0;
    private float hp = 100f;

    public static PlayerManager instance;

    //I am an artist, a performance artist
    //fafafafafafafafa
    private IPerformanceArtist van_sama;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

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
        //Debug.Log(DrawWave.instance.GetOriginYPos());
        //Debug.Log(playerYPos);
        if (Mathf.Abs(DrawWave.instance.GetOriginYPos() - playerYPos) > thatsGood)
        {
            hp -= damage;
        }

        if (hp < 99.8)
        {
            hp += recover;
        }
        else
        {
            hp = 100;
        }
    }

    public float GetPoints()
    {
        return hp;
    }
}
