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
       
        Debug.Log("I am called");
        var s = Instantiate(BloodPrefab, _transform, Quaternion.identity);
        if(s != null)
        {
            Debug.Log("Object Made");
        }
    }
}
