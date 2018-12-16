using UnityEngine.UI;
using UnityEngine;

public class Moster : MonoBehaviour {

    
    public Image HealthBar;
    Canvas ca;
    private float power;
    private float speed;

    // Use this for initialization
    void Start ()
    {
        speed = 0.8f;
        power = 0.1f;
        HealthBar=gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
    }
	// Update is called once per frame
	void Update ()
    {
       this.transform.Translate(Vector2.right *speed * Time.deltaTime);
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
        HealthBar.fillAmount -=power;
    }
    void killMoster()
    {
        Destroy(gameObject);
    }
}
