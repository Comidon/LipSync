using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWave : MonoBehaviour
{
    [SerializeField]
    List<Vector3> poss;

    [SerializeField]
    Vector3 velocity;

    private void Awake()
    {
        poss = new List<Vector3>();
        //poss = new Vector3[5];
        GetComponent<LineRenderer>().GetPositions(poss.ToArray());

        
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Vector3 asdf in poss)
        {
            Debug.Log("");
            Debug.Log(asdf);
            ShiftLeft();
        }
    }

    void ShiftLeft()
    {
        for (int i = 0; i < poss.Count; i++)
        {
            poss[i] += velocity;
        }

        if (poss[1].x < 0)
        {
            poss.RemoveAt(0);
        }
    }
}
