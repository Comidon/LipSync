using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongDrawer : MonoBehaviour
{
    [SerializeField]
    float low;

    [SerializeField]
    float high;

    [SerializeField]
    float deleteX;

    [SerializeField]
    GameObject point;

    private float destoryOffset = -4f;
    private float songBpm = 130;

    //How many seconds have passed since the song started
    public float dspSongTime;

    public static SongDrawer instance;

    //The number of seconds for each song beat
    private float secPerBeat;

    private LineRenderer line1;
    private LineRenderer line2;

    private List<Vector3> poss;
    private List<Vector3> possR;

    private List<GameObject> points;

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

    private float lengthFactor = 4;

    private float beatLength;

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

        beatCounter = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        beatLength = lengthFactor * secPerBeat;

        Debug.Log("It's X: " + x);

        poss.Add(new Vector3(x, y + low, z));

        points = new List<GameObject>();
        points.Add(Instantiate(point, new Vector3(x, y + low, z), Quaternion.identity));

        AddBlank(32);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddBlank(16);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddBlank(16);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddBlank(16);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddTri();
        AddPlat(2);

        possR = new List<Vector3>(poss);

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
        poss.Add(new Vector3((beatCounter + 1) * beatLength / 4 + x, y + high, z));
        poss.Add(new Vector3((beatCounter + 2) * beatLength / 4 + x, y + low, z));

        points.Add(Instantiate(point, new Vector3((beatCounter + 1) * beatLength / 4 + x, y + high, z), Quaternion.identity));
        points.Add(Instantiate(point, new Vector3((beatCounter + 2) * beatLength / 4 + x, y + low, z), Quaternion.identity));

        beatCounter += 2;
    }

    public void AddBlank(int numOfBeats)
    {
        poss.Add(new Vector3((beatCounter + numOfBeats) * beatLength / 4 + x, y + low, z));

        points.Add(Instantiate(point, new Vector3((beatCounter + numOfBeats) * beatLength / 4 + x, y + low, z), Quaternion.identity));

        beatCounter += numOfBeats;
    }

    public void AddPlat(int numOfBeats)
    {
        poss.Add(new Vector3((beatCounter + 1) * beatLength / 4 + x, y + high, z));
        poss.Add(new Vector3((beatCounter + 1 + numOfBeats) * beatLength / 4 + x, y + high, z));
        poss.Add(new Vector3((beatCounter + 2 + numOfBeats) * beatLength / 4 + x, y + low, z));

        points.Add(Instantiate(point, new Vector3((beatCounter + 1) * beatLength / 4 + x, y + high, z), Quaternion.identity));
        points.Add(Instantiate(point, new Vector3((beatCounter + 1 + numOfBeats) * beatLength / 4 + x, y + high, z), Quaternion.identity));
        points.Add(Instantiate(point, new Vector3((beatCounter + 2 + numOfBeats) * beatLength / 4 + x, y + low, z), Quaternion.identity));

        beatCounter += numOfBeats + 2;
    }

    private void FixedUpdate()
    {
        _ShiftLeft();

        int positiveIndex = 0;

        for (int i = 0; i < poss.Count; i++)
        {
            if (poss[i].x > x)
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
            poss[i] = new Vector3(possR[i].x - 2 * songPosition, poss[i].y, poss[i].z);
            points[i].transform.position = new Vector3(possR[i].x - 2 * songPosition, poss[i].y, poss[i].z);
        }

        if (poss.Count >= 2 && poss[1].x < x + destoryOffset && poss[1].y.Equals(low + y))
        {
            poss.RemoveAt(0);
            possR.RemoveAt(0);
            points.RemoveAt(0);
        }
        else if (poss.Count >= 3 && poss[2].x < x + destoryOffset && poss[2].y.Equals(low + y))
        {
            poss.RemoveRange(0, 2);
            possR.RemoveRange(0, 2);
            points.RemoveRange(0, 2);
        }
        else if (poss.Count >= 4 && poss[3].x < x + destoryOffset && poss[3].y.Equals(low + y))
        {
            poss.RemoveRange(0, 3);
            possR.RemoveRange(0, 3);
            points.RemoveRange(0, 3);
        }
        else if (poss.Count == 1)
        {
            poss.RemoveAt(0);
            possR.RemoveAt(0);
            points.RemoveAt(0);
        }

        if (poss.Count < 25)
        {
            Vector3[] tempPoss = new Vector3[poss.Count + 2];
            Vector3[] tempPossM = new Vector3[poss.Count + 2];

            poss.CopyTo(tempPoss, 1);

            // Set init pos
            tempPoss[0] = new Vector3(x - 100, y + low, z);
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
        else
        {
            Vector3[] tempPoss = new Vector3[25 + 2];
            Vector3[] tempPossM = new Vector3[25 + 2];

            System.Array.Copy(poss.ToArray(), 0, tempPoss, 1, 25);

            // Set init pos
            tempPoss[0] = new Vector3(x - 100, y + low, z);
            // Set far pos
            tempPoss[25 + 1] = new Vector3(x + 100, y + low, z);

            for (int i = 0; i < 25 + 2; i++)
            {
                tempPossM[i] = new Vector3(tempPoss[i].x, 2 * y - tempPoss[i].y, tempPoss[i].z);
            }

            line1.positionCount = 25 + 2;
            line2.positionCount = 25 + 2;
            line1.SetPositions(tempPoss);
            line2.SetPositions(tempPossM);
        }
    }
}
