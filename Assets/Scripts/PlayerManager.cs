using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float thatsGood = 0.149f;

    private float damage = 10f;

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
<<<<<<< HEAD
        //playerYPos = van_sama.GetLipsPosition().y;
        /*playerYPos = Input.GetAxis("Vertical") * 0.45f + 0.8f;*/
=======
        playerYPos = van_sama.GetLipsPosition().y;
>>>>>>> Yuhan
    }

    private void FixedUpdate()
    {
        Debug.Log(hp);
<<<<<<< HEAD
        /*Debug.Log("Line pos: " + SongDrawer.instance.GetOriginYPos());
        Debug.Log("Player pos: " + playerYPos);*/
        /*if (Mathf.Abs(SongDrawer.instance.GetOriginYPos() - playerYPos) > thatsGood)
=======
        //Debug.Log("Line pos: " + DrawWave.instance.GetOriginYPos());
        //Debug.Log("Player pos: " + playerYPos);
        if (Mathf.Abs(DrawWave.instance.GetOriginYPos() - playerYPos) > thatsGood)
>>>>>>> Yuhan
        {
            hp -= damage;
        }

        if (hp < 99.8)
        {
            hp += recover;
        }
        else
        {*/
        if (hp < 99.8)
        {
<<<<<<< HEAD
            hp += recover;
=======
            hp = 100;
>>>>>>> Yuhan
        }
        else
        {
            hp = 100;
        }
        //}
    }

    public float GetPoints()
    {
        return hp;
    }

    public void TakeDamage()
    {
        hp -= damage;
    }
}
