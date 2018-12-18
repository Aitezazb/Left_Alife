using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticularManger : MonoBehaviour {

    public GameObject BloodPrefab; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MakeBlood(Vector3 _transform)
    {

        //_transform.z = -4.115f;
        _transform.z = BloodPrefab.transform.position.z;
        var s = Instantiate(BloodPrefab, _transform, Quaternion.identity);
        
    }
}
