using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraScene
{
    Bedroom,
    Downstairs,
    Study,
    TV,
    Window,
    Sofa
}
public class CameraManager : MonoBehaviour
{
    public GameObject cameraBedroom;
    public GameObject cameraDownstairs;
    public GameObject cameraStudy;
    public GameObject cameraTV;
    public GameObject cameraWindow;
    public GameObject cameraSofa;

    public CameraScene index = CameraScene.Bedroom;
    private CameraScene tarIndex;

    private bool moving = true;

    public void ChangeCamera()
    {
        GetComponent<Animator>().SetTrigger("Change");
    }
    public void ManageCamera()
    {
        switch (index)
        {
            case CameraScene.Bedroom:
                cameraBedroom.SetActive(false);
                break;
            default:
                break;
        }

        switch (tarIndex)
        {
            case CameraScene.Bedroom:
                cameraBedroom.SetActive(true);
                break;
            case CameraScene.Downstairs:
                cameraDownstairs.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void setMoving(bool mov)
    {
        this.moving = mov;
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
        if (moving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                moveW();
            }
        }
    }

    private void moveW()
    {
        switch (index)
        {
            case CameraScene.Bedroom:
                tarIndex = CameraScene.Downstairs;
                break;
            default:
                break;
        }
        ChangeCamera();
    }
}
