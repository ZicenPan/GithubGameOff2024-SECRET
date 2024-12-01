using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum Story
{
    Beginning,
    D1Eat
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CatFood ()
    {
        animationManager.stopAnimation(AniTimeline.WantEat);
        animationManager.playAnimation(AniTimeline.Eat);
        catFood.gameObject.SetActive(false);
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
                    dialogueBox.setProgressing(false);
                }
                if (cameraManager.index == CameraScene.Downstairs)
                {
                    cameraManager.setMoving(false);
                    dialogueBox.setProgressing(true);
                    dialogueBox.NextLine();
                    dialogueBox.setProgressing(false);
                    catFood.gameObject.SetActive(true);
                    curStage = Story.D1Eat;
                }
                break;
            case Story.D1Eat:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        storyProgress();
    }
}
