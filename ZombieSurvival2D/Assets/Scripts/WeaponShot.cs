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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
