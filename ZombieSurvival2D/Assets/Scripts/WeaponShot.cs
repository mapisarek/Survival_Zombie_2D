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


        if (Input.GetKey(KeyCode.Alpha2))
        {
            CanUse = 1;

        }


    }
}
