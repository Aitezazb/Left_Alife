using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMember : MonoBehaviour {

    public GameObject Main1;
    public GameObject Player;
    public GameObject coins;

    public GameObject teamMember;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TeamMember_OnClick()
    {
        Main1.SetActive(false);
        Player.SetActive(false);
        coins.SetActive(false);
        teamMember.SetActive(true);
    }

    public void TeamMemberCross_OnClick()
    {
        Main1.SetActive(true);
        Player.SetActive(true);
        coins.SetActive(true);
        teamMember.SetActive(false);
    }
}
