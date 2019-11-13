using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public string DisplayText;
    public int DisplayPoints;
    public Text TextPrefab;
    public float Speed;
    public float DestroyAfter;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = DestroyAfter;
        TextPrefab = GetComponentInChildren<Text>();
    }
    

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer<0)
        {
            Destroy(gameObject);
        }
        if(DisplayText != null)
        {
            TextPrefab.text = DisplayText;
        }
        if(Speed>0)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.World);
        }
    }
}
