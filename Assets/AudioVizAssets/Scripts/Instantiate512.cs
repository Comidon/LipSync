using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512 : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[64];
    public float _maxScale;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 64; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.rotation = this.transform.rotation;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.localEulerAngles = new Vector3(0, -0.703125f * i * 8, 0);
            _instanceSampleCube.transform.position = Vector3.forward;
            _sampleCube[i] = _instanceSampleCube;
          
      
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 64; i++)
        {
            if(_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(2.5f, (AudioVisual._samples[i] * _maxScale) / 8 + 0.25f, 2.5f);
            }
        }
    }
}
