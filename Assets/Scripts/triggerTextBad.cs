﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerTextBad : MonoBehaviour
{
    public string TextToShow;
    private float tempShake =100f;
    private float getShake;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getShake = PlayerManager.instance.GetPoints();
        /*if (tempShake + 10 < getShake)
        {
            SpawnText();
            //tempShake = getShake;
        }*/
        if(tempShake-10f>getShake)
        {
            SpawnTextBad();
            tempShake = getShake;
        }
    }
    /*public void SpawnText()
    {
        tempShake = getShake;
        GameObject PointsText = Instantiate(Resources.Load("Prefab/TextOnSpot")) as GameObject;
        if (PointsText.GetComponent<TextDisplay>() != null)
        {
            var givePointText = PointsText.GetComponent<TextDisplay>();
            givePointText.DisplayText = TextToShow;
        }
        //PointsText.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+100,gameObject.transform.position.z);
        PointsText.transform.position = gameObject.transform.position;
    }*/
    public void SpawnTextBad()
    {
        
        GameObject PointsText = Instantiate(Resources.Load("Prefab/TextOnSpotBad")) as GameObject;
        if (PointsText.GetComponent<TextDisplay>() != null)
        {
            var givePointText = PointsText.GetComponent<TextDisplay>();
            givePointText.DisplayText = TextToShow;
        }
        //PointsText.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+100,gameObject.transform.position.z);
        PointsText.transform.position = gameObject.transform.position;
        
    }
}
