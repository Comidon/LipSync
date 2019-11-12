﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongDrawer : MonoBehaviour
{
    [SerializeField]
    Vector3 velocity;

    [SerializeField]
    float low;

    [SerializeField]
    float high;

    [SerializeField]
    float deleteX;

    private float songBpm = 130;

    //How many seconds have passed since the song started
    public float dspSongTime;

    public static SongDrawer instance;

    //The number of seconds for each song beat
    private float secPerBeat;

    private LineRenderer line1;
    private LineRenderer line2;

    private List<Vector3> poss;

    private float beatCounter;

    private float currentYPos = 0;

    private AudioSource beep;

    private float beeper = 0;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    private float x;
    private float y;
    private float z;

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

        poss = new List<Vector3>();

        line1 = GetComponentsInChildren<LineRenderer>()[0];
        line2 = GetComponentsInChildren<LineRenderer>()[1];

        beep = GetComponent<AudioSource>();
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        beatCounter = x;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        beep.Play();
    }

    private void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
    }

    public float GetOriginYPos()
    {
        return currentYPos;
    }

    public void AddTri()
    {
        poss.Add(new Vector3(beatCounter + 1, y + high, z));
        poss.Add(new Vector3(beatCounter + 2, y + low, z));
        beatCounter += 2;
    }

    public void AddBlank(int numOfBeats)
    {
        poss.Add(new Vector3(beatCounter + numOfBeats * 2, y + low, z));
        beatCounter += numOfBeats * 2;
    }

    public void AddPlat(int numOfBeats)
    {
        poss.Add(new Vector3(beatCounter + 1, y + high, z));
        poss.Add(new Vector3(beatCounter + 1 + numOfBeats * 2, y + high, z));
        poss.Add(new Vector3(beatCounter + 2 + numOfBeats * 2, y + low, z));
        beatCounter += numOfBeats * 2 + 2;
    }

    private void FixedUpdate()
    {
        _ShiftLeft();

        int positiveIndex = 0;

        for (int i = 0; i < poss.Count; i++)
        {
            if (poss[i].x > 0)
            {
                positiveIndex = i;
                break;
            }
        }

        if (positiveIndex != 0)
        {
            currentYPos = (x - poss[positiveIndex - 1].x) * ((poss[positiveIndex].y - poss[positiveIndex - 1].y) / (poss[positiveIndex].x - poss[positiveIndex - 1].x)) + poss[positiveIndex - 1].y - y;
        }
        else
        {
            currentYPos = low;
        }
    }

    private void _ShiftLeft()
    {
        for (int i = 0; i < poss.Count; i++)
        {
            poss[i] += velocity;
        }

        if (poss.Count >= 2 && poss[1].x < x && poss[1].y.Equals(low + y))
        {
            poss.RemoveAt(0);
            _RandomInstantiate(poss[poss.Count - 1].x);
        }
        else if (poss.Count >= 3 && poss[2].x < x && poss[2].y.Equals(low + y))
        {
            poss.RemoveRange(0, 2);
            _RandomInstantiate(poss[poss.Count - 1].x);
        }
        else if (poss.Count >= 4 && poss[3].x < x && poss[3].y.Equals(low + y))
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
        Vector3[] tempPossM = new Vector3[poss.Count + 2];

        poss.CopyTo(tempPoss, 1);

        // Set init pos
        tempPoss[0] = new Vector3(x - 10, y + low, z);
        // Set far pos
        tempPoss[poss.Count + 1] = new Vector3(x + 100, y + low, z);

        for (int i = 0; i < tempPoss.Length; i++)
        {
            tempPossM[i] = new Vector3(tempPoss[i].x, 2 * y - tempPoss[i].y, tempPoss[i].z);
        }

        line1.positionCount = poss.Count + 2;
        line2.positionCount = poss.Count + 2;
        line1.SetPositions(tempPoss);
        line2.SetPositions(tempPossM);
    }

    private void _RandomInstantiate(float pos)
    {
        float rand = Random.Range(0f, 4f);
        beatCounter = pos;

        int randLength = (int)Mathf.Floor(Random.Range(1, 3.49999999f));

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
