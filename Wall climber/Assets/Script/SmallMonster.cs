using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class SmallMonster : MonoBehaviour {


    private GameObject gameManager;
    private GameObject particularManager;
    private float speed;
    private Image HealthBar;
    Canvas ca;
    public float Damagepower;
    private GameObject UpGradeGun;

    // Use this for initialization
    void Start()
    {
        particularManager = GameObject.Find("ParticularManger");
        gameManager = GameObject.Find("GameManger");
        speed = 0.8f;
        Damagepower = 0f;
        HealthBar = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        UpGradeGun = GameObject.Find("UpGrade Gun Manger");
        Damagepower = UpGradeGun.GetComponent<UpgradeGunManger>().Get_CurrentGun();
      
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            if (HealthBar.fillAmount > 0)
            {
                ReduceHealth();
            }
            else
            {
                gameManager.GetComponent<GameManger>().UpdateScore();
                killMoster();

            }
        }
        if(coll.gameObject.tag == "RainBullet")
        {
            killMoster();
        }
        if (coll.gameObject.tag == "Emeny")
        {
            killMoster();
        }

    }
    void ReduceHealth()
    {
        HealthBar.fillAmount -= Damagepower;

    }
    void killMoster()
    {
        particularManager.GetComponent<ParticularManger>().MakeBlood(this.transform.position);
        Destroy(gameObject);
    }
}
