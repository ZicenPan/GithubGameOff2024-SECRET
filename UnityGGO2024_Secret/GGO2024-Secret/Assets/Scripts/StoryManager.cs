using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Story
{
    Beginning,
    D1Eat,
    D1Love,
    D1GoToWork
}
public class StoryManager : MonoBehaviour
{
    public Story curStage = Story.Beginning;
    public SoundManager soundManager;
    public DialogueBox dialogueBox;
    public CameraManager cameraManager;
    public AnimationManager animationManager;

    public Button catFood;

    private bool reading = true;

    private float curTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CatFood ()
    {
        animationManager.stopAnimation(AniTimeline.WantEat);
        animationManager.playAnimation(AniTimeline.Eat);
        catFood.gameObject.SetActive(false);
        curStage = Story.D1Love;
    }

    private void toggleMove()
    {
        cameraManager.setMoving(reading);
        dialogueBox.setProgressing(!reading);
        reading = !reading;
    }
    private void storyProgress()
    {
        switch(curStage) 
        {
            case Story.Beginning:
                if (dialogueBox.getIndex() == 2 && dialogueBox.lineFinished())
                {
                    cameraManager.setMoving(true);
                    cameraManager.loadUI(CameraScene.Bedroom);
                    dialogueBox.setProgressing(false);
                }
                if (cameraManager.index == CameraScene.Downstairs)
                {
                    cameraManager.setMoving(false);
                    cameraManager.unloadUI(CameraScene.Bedroom);
                    soundManager.setPlaying(false);
                    dialogueBox.setProgressing(true);
                    if (dialogueBox.getIndex() == 3 && dialogueBox.lineFinished())
                    {
                        dialogueBox.setProgressing(false);
                        catFood.gameObject.SetActive(true);
                        curStage = Story.D1Eat;
                    }
                }
                break;
            case Story.D1Eat:
                break;
            case Story.D1Love:
                curTimer += Time.deltaTime;
                if (curTimer > 6.0f)
                {
                    animationManager.OnEatStopped();
                    curStage = Story.D1GoToWork;
                }
                break;
            case Story.D1GoToWork:
                dialogueBox.setProgressing(true);
                if (dialogueBox.getIndex() == 4 && dialogueBox.lineFinished())
                {
                    cameraManager.setMoving(true);
                    cameraManager.loadUI(CameraScene.Downstairs);
                    dialogueBox.setProgressing(false);
                }
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        storyProgress();
    }
}
