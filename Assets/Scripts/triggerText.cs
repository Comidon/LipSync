using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerText : MonoBehaviour
{
    public string TextToShow;
    public string TextToShow2;
    private float tempShake = 100f;
    public static float getShake;
    public Transform sparkle;
    public Transform sparkleBad;
    // Start is called before the first frame update
    void Start()
    {
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
        sparkleBad.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        getShake = PlayerManager.instance.GetPoints();
        if(tempShake+10<getShake)
        {
            SpawnText();
            tempShake = getShake;
        }
        else if(tempShake-10>getShake)
        {
            SpawnTextBad();
            tempShake = getShake;
        }
        
    }
    public void SpawnText()
    {
        sparkle.GetComponent<ParticleSystem>().enableEmission = true;
        StartCoroutine(stopSparkles());
        GameObject PointsText = Instantiate(Resources.Load("Prefab/TextOnSpot")) as GameObject;
        if (PointsText.GetComponent<TextDisplay>() != null)
        {
            var givePointText = PointsText.GetComponent<TextDisplay>();
            givePointText.DisplayText = TextToShow;
        }
        //PointsText.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+100,gameObject.transform.position.z);
        PointsText.transform.position = gameObject.transform.position;
        
    }
    public void SpawnTextBad()
    {
        sparkleBad.GetComponent<ParticleSystem>().enableEmission = true;
        StartCoroutine(stopSparklesBad());
        GameObject PointsText = Instantiate(Resources.Load("Prefab/TextOnSpotBad")) as GameObject;
        if (PointsText.GetComponent<TextDisplay>() != null)
        {
            var givePointText = PointsText.GetComponent<TextDisplay>();
            givePointText.DisplayText = TextToShow2;
        }
        //PointsText.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+100,gameObject.transform.position.z);
        PointsText.transform.position = gameObject.transform.position;
    }

    IEnumerator stopSparkles()
    {
        yield return new WaitForSeconds(0.4f);
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }
    IEnumerator stopSparklesBad()
    {
        yield return new WaitForSeconds(0.4f);
        sparkleBad.GetComponent<ParticleSystem>().enableEmission = false;
    }
}
