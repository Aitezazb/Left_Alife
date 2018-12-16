using UnityEngine.UI;
using UnityEngine;

public class SmallMonster : MonoBehaviour {


    private GameObject gameManager;

    private float speed;
    private Image HealthBar;
    Canvas ca;
    public float Damagepower;
    private GameObject UpGradeGun;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManger");
        speed = 0.8f;
        Damagepower = 0f;
        HealthBar = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        UpGradeGun = GameObject.Find("UpGrade Gun Manger");
        Damagepower = UpGradeGun.GetComponent<UpgradeGunManger>().Get_CurrentGun();
        Debug.Log("DamagePowr" + Damagepower);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //Gamover
            Debug.Log("Game Over");
        }
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

    }
    void ReduceHealth()
    {
        HealthBar.fillAmount -= Damagepower;

    }
    void killMoster()
    {
        Destroy(gameObject);
    }
}
