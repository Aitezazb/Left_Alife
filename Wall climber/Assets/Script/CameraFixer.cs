using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixer : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        float xFactor = Screen.width / 800f;
        float yFactor = Screen.height / 480f;

        Camera.main.rect = new Rect(0, 0, 1, xFactor / yFactor);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
