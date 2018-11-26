using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFired : MonoBehaviour {

    public Transform bulletPerfeb;
    public Transform BulletPosition;

    public float speed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform bullet;
        Vector3 InputMouse;float step = speed * Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            
            bullet =  Instantiate(bulletPerfeb, BulletPosition.position, Quaternion.identity);
            //Debug.Log(Input.mousePosition);
            InputMouse = Input.mousePosition;
            
        }
        
    }
}
