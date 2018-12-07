using UnityEngine.UI;
using UnityEngine;

public class SmallMonster : MonoBehaviour {

    private float speed;
    private Image HealthBar;
    Canvas ca;
    public float Damagepower;
    private GameObject UpGradeGun;
    
	// Use this for initialization
	void Start ()
    {
        speed = 0.8f;
        Damagepower = 0f;
        HealthBar=gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        UpGradeGun = GameObject.Find("UpGrade Gun Manger");
        Damagepower = UpGradeGun.GetComponent<UpgradeGunManger>().Get_CurrentGun();
        Debug.Log("got the damage" + Damagepower);

    }
	// Update is called once per frame
	void Update ()
    {
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("From the collision"+ coll.gameObject.tag);
        if (coll.gameObject.tag == "Player")
        {
            //Gamover
            Debug.Log("Game Over");
        }
        if(coll.gameObject.tag == "Bullet")
        {
            if(HealthBar.fillAmount > 0)
            {
                ReduceHealth();
            }
            else
            {
                killMoster();
            }
        }

    }
    void ReduceHealth()
    {
        HealthBar.fillAmount -=Damagepower;
        Debug.Log("da" + Damagepower);
    }
    void killMoster()
    {
        Destroy(gameObject);
    }
    public void DamagePowerchange()
    {

    }
}
