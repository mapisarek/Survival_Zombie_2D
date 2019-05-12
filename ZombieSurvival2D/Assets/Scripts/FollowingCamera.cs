using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject characterList;
    private int index;
    private CinemachineVirtualCamera camFollower;

    public void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        SetUpCamera();

    }

    private void SetUpCamera()
    {
        camFollower = GameObject.Find("FollowCam").GetComponent<CinemachineVirtualCamera>();
        camFollower.Follow = characterList.transform.GetChild(index);
        camFollower.LookAt = characterList.transform.GetChild(index);
    }

}
