using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    private GameObject floatTextPrefab;

    [SerializeField]
    private Color[] textColor;

    [SerializeField]
    private float textKillTime;

    // Update is called once per frame
    void Update()
    {
        if(AudienceControl.shakeAmt>0)
        {
            textNow();
        }
    }
    public void textNow()
    {
        GameObject newText = Instantiate(floatTextPrefab, playerObject.transform.position, Quaternion.identity);
        newText.SetActive(true);
        newText.GetComponent<FloatTextController>().SetTextAndMove(Random.Range(0,101).ToString(), textColor[Random.Range(0, textColor.Length)]);
        Destroy(newText.gameObject, textKillTime);

    }
}
