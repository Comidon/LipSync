using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWave : MonoBehaviour
{
    [SerializeField]
    //This is determined by the song you're trying to sync up to
    private float songBpm;

    [SerializeField]
    Vector3 velocity;

    //The number of seconds for each song beat
    private float secPerBeat;

    private LineRenderer line;
    private List<Vector3> poss;

    private float beatCounter = 0;

    private void Awake()
    {
        poss = new List<Vector3>();
        line = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        AddBlank(1);
        AddBlank(1);
        AddBlank(1);
        AddBlank(1);
        AddBlank(1);
        AddBlank(1);
        AddBlank(1);
        AddBlank(1);
        AddBlank(2);
        AddBlank(2);
        AddBlank(2);
        AddBlank(2);
        AddBlank(2);
        AddBlank(2);

        line.SetPositions(poss.ToArray());
    }

    public void AddTri()
    {
        poss.Add(new Vector3(beatCounter + 1, 2, 0));
        poss.Add(new Vector3(beatCounter + 2, 0, 0));
        beatCounter += 2;
    }

    public void AddBlank(int numOfBeats)
    {
        poss.Add(new Vector3(beatCounter + numOfBeats * 2, 0, 0));
        beatCounter += numOfBeats * 2;
    }

    public void AddPlat(int numOfBeats)
    {
        poss.Add(new Vector3(beatCounter + 1, 2, 0));
        poss.Add(new Vector3(beatCounter + 1 + numOfBeats * 2, 2, 0));
        poss.Add(new Vector3(beatCounter + 2 + numOfBeats * 2, 0, 0));
        beatCounter += numOfBeats * 2 + 2;
    }

    private void FixedUpdate()
    {
        _ShiftLeft();
    }

    private void _ShiftLeft()
    {
        for (int i = 0; i < poss.Count; i++)
        {
            poss[i] += velocity;
        }

        if (poss.Count >= 2 && poss[1].x < 0 && poss[1].y == 0)
        {
            poss.RemoveAt(0);
            _RandomInstantiate(poss[poss.Count - 1].x);
        }
        else if (poss.Count >= 3 && poss[2].x < 0 && poss[2].y == 0)
        {
            poss.RemoveRange(0, 2);
            _RandomInstantiate(poss[poss.Count - 1].x);
        }
        else if (poss.Count >= 4 && poss[3].x < 0 && poss[3].y == 0)
        {
            poss.RemoveRange(0, 3);
            _RandomInstantiate(poss[poss.Count - 1].x);
        }
        else if (poss.Count == 1)
        {
            poss.RemoveAt(0);
            _RandomInstantiate(poss[poss.Count - 1].x);
        }

        Vector3[] tempPoss = new Vector3[poss.Count + 2];

        poss.CopyTo(tempPoss, 1);

        // Set init pos
        tempPoss[0] = new Vector3(-10, 0, 0);
        // Set far pos
        tempPoss[poss.Count + 1] = new Vector3(100, 0, 0);

        line.positionCount = poss.Count + 2;
        line.SetPositions(tempPoss);
    }

    private void _RandomInstantiate(float pos)
    {
        float rand = Random.Range(0f, 4f);
        beatCounter = pos;

        int randLength = (int) Mathf.Floor(Random.Range(1, 3.49999999f));

        Debug.Log(rand);

        if (rand < 1.5)
        {
            AddTri();
        }
        else if (rand < 3.3)
        {
            AddBlank(randLength);
        }
        else
        {
            AddPlat(randLength);
        }
    }
}
