using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cameraBedroom;
    public GameObject cameraDownstairs;
    public int index = 0;

    public void ManageCamera()
    {
        if (index == 0)
        {
            Cam_2();
            index = 1;
        } else
        {
            Cam_1();
            index = 0;
        }
    }
    void Cam_1()
    {
        cameraBedroom.SetActive(true);
        cameraDownstairs.SetActive(false);
    }

    void Cam_2()
    {
        cameraBedroom.SetActive(false);
        cameraDownstairs.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
