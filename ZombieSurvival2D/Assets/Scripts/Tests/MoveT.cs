using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveT : MonoBehaviour
{
    public CharacterController CharControl;

    private void Awake()
    {
        CharControl = GetComponent<CharacterController>();
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        CharControl.Move(new Vector3(horizontal, 0, vertical));


    }
}
