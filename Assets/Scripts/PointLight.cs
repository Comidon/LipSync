using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]

public class PointLight : MonoBehaviour
{

    public float time = .5f; //time between on and off

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Flicker");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Flicker()
    {
        while (true)
        {
            gameObject.GetComponent<Light>().enabled=false;
            yield return new WaitForSeconds(time);
            gameObject.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(time);
            if (gameObject.GetComponent<Light>().enabled == true)
            {
                gameObject.GetComponent<Light>().color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
}
