using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShot : MonoBehaviour
{

    private Rigidbody2D rig;
    private Vector2 spherePosition;
    public GameObject prefab;
    private float canShot = 0.0f;
    private float canAmo = 0.0f;
    public int amo = 300;
    public int magazin = 3;
    private int rel = 0;
    public int damage = 1;
    public bool isEnemyShot = false;
    private float barWidth;
    private float barHeight;
    private int CanUse = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var moues = Input.mousePosition;
        //var screenPoint = Camera.main.ViewportToScreenPoint(transform.localPosition);
        var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        var offset = new Vector2(moues.x - screenPoint.x, moues.y - screenPoint.y);
        var angel = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        Quaternion a = transform.rotation = Quaternion.Euler(0, 0, angel);



        if (Input.GetKey(KeyCode.Alpha1))
        {
            CanUse = 0;

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            CanUse = 1;

        }

        if (Input.GetKey(KeyCode.Mouse0) && CanUse == 1)
        {
            if (canShot <= 0.0f && amo > 0)
            {
                amo -= 1;
                canShot = 0.01f;
                fire();
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            if (magazin > 0 && amo >= 0 && amo < 300)
            {
                amo = 0;
                if (rel == 0)
                {
                    rel = 1;
                    magazin -= 1;

                }
                canAmo = 2f;




            }
        }




        if (canShot > 0.0f)
        {
            canShot -= Time.deltaTime;

        }
        if (canAmo > 0.0f)
        {
            canAmo -= Time.deltaTime;

        }
        if (amo == 0 && rel == 1 && canAmo <= 0.0f)
        {
            amo = 300;
            rel = 0;
        }



    }


    void fire()
    {

        var moues = Input.mousePosition;
        //var screenPoint = Camera.main.ViewportToScreenPoint(transform.localPosition);
        var screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        var offset = new Vector2(moues.x - screenPoint.x, moues.y - screenPoint.y);
        var angel = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        var myszx = Input.mousePosition.x;
        var myszy = Input.mousePosition.y;
        var kamerax = Camera.main.WorldToScreenPoint(transform.position).x;
        var kameray = Camera.main.WorldToScreenPoint(transform.position).y;
        float balans = 1000 / Mathf.Sqrt(((myszx - kamerax) * (myszx - kamerax)) + ((myszy - kameray) * (myszy - kameray)));

        var dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * balans;

        GameObject g = (GameObject)Instantiate(prefab, transform.position + dir / 30, Quaternion.Euler(0, 0, angel));
        Destroy(g, 1);
        g.GetComponent<Rigidbody2D>().gravityScale = 0;
        g.GetComponent<Rigidbody2D>().AddForce(dir * 50);

        //
    }

    void Awake()
    {
        barHeight = Screen.height * 0.02f;
        barWidth = barHeight * 10.0f;
    }

    void OnGUI()
    {

        GUI.TextField(new Rect(Screen.width - barWidth - 20,
                                Screen.height - barHeight * 3 - 50,
                                30,
                                20),
                                amo.ToString());
        GUI.TextField(new Rect(Screen.width - barWidth + 10,
                                Screen.height - barHeight * 3 - 50,
                                20,
                                20),
                                magazin.ToString());
        GUI.TextField(new Rect(Screen.width - barWidth - 20,
                                Screen.height - barHeight * 3 - 70,
                                30,
                                20),
                                amo.ToString());



    }

}
