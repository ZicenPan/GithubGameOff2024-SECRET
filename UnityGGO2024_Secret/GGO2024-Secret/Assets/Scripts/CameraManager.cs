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
    public GameObject UIBedroom;
    public GameObject UIDownstairs;
    public GameObject UIStudy;
    public GameObject UITV;
    public GameObject UIWindow;
    public GameObject UISofa;

    public CameraScene index = CameraScene.Bedroom;
    private CameraScene tarIndex;

    private bool moving = false;

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
                UIBedroom.SetActive(false);
                break;
            case CameraScene.Downstairs:
                cameraDownstairs.SetActive(false);
                UIDownstairs.SetActive(false);
                break;
            case CameraScene.Study:
                cameraStudy.SetActive(false);
                UIStudy.SetActive(false);
                break;
            case CameraScene.TV:
                cameraTV.SetActive(false);
                UITV.SetActive(false);
                break;
            case CameraScene.Window:
                cameraWindow.SetActive(false);
                UIWindow.SetActive(false);
                break;
            case CameraScene.Sofa:
                cameraSofa.SetActive(false);
                UISofa.SetActive(false);
                break;
            default:
                break;
        }

        switch (tarIndex)
        {
            case CameraScene.Bedroom:
                cameraBedroom.SetActive(true);
                UIBedroom.SetActive(true);
                break;
            case CameraScene.Downstairs:
                cameraDownstairs.SetActive(true);
                UIDownstairs.SetActive(true);
                break;
            case CameraScene.TV:
                cameraTV.SetActive(true);
                UITV.SetActive(true);
                break;
            case CameraScene.Study:
                cameraStudy.SetActive(true);
                UIStudy.SetActive(true);
                break;
            case CameraScene.Window:
                cameraWindow.SetActive(true);
                UIWindow.SetActive(true);
                break;
            case CameraScene.Sofa:
                cameraSofa.SetActive(true);
                UISofa.SetActive(true);
                break;
            default:
                break;
        }
        index = tarIndex;
    }

    public void loadUI(CameraScene index)
    {
        switch (index)
        {
            case CameraScene.Bedroom:
                UIBedroom.SetActive(true);
                break;
            case CameraScene.Downstairs:
                UIDownstairs.SetActive(true);
                break;
            case CameraScene.TV:
                UITV.SetActive(true);
                break;
            case CameraScene.Study:
                UIStudy.SetActive(true);
                break;
            case CameraScene.Window:
                UIWindow.SetActive(true);
                break;
            case CameraScene.Sofa:
                UISofa.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void unloadUI(CameraScene index)
    {
        switch (index)
        {
            case CameraScene.Bedroom:
                UIBedroom.SetActive(false);
                break;
            case CameraScene.Downstairs:
                UIDownstairs.SetActive(false);
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
            else if (Input.GetKeyDown(KeyCode.D))
            {
                moveD();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                moveA();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                moveS();
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
            case CameraScene.Downstairs:
                tarIndex = CameraScene.Bedroom;
                break;
            case CameraScene.TV:
                tarIndex = CameraScene.Study;
                break;
            default:
                break;
        }
        ChangeCamera();
    }
    private void moveD()
    {
        switch (index)
        {
            case CameraScene.Downstairs:
                tarIndex = CameraScene.TV;
                break;
            case CameraScene.TV:
                tarIndex = CameraScene.Window;
                break;
            case CameraScene.Window:
                tarIndex = CameraScene.Sofa;
                break;
            default:
                break;
        }
        ChangeCamera();
    }
    private void moveA()
    {
        switch (index)
        {
            case CameraScene.TV:
                tarIndex = CameraScene.Downstairs;
                break;
            case CameraScene.Window:
                tarIndex = CameraScene.TV;
                break;
            default:
                break;
        }
        ChangeCamera();
    }
    private void moveS()
    {
        switch (index)
        {
            case CameraScene.Study:
                tarIndex = CameraScene.TV;
                break;
            default:
                break;
        }
        ChangeCamera();
    }

}
