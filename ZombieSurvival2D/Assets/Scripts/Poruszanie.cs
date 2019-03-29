using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poruszanie : MonoBehaviour
{

     
    float speed = 200;
    private Rigidbody2D rig;
    public Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, vAxis, vAxis) * speed * Time.deltaTime;
        rig.MovePosition(transform.position+movement);


        m_Animator.SetFloat("Poziom", hAxis);
        m_Animator.SetFloat("Pion", vAxis);



    }
}
