using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void storyProgress()
    {
        switch(curStage) 
        {
            case Story.Beginning:
                if (dialogueBox.getIndex() == 3 && dialogueBox.lineFinished())
                {
                    cameraManager.setMoving(true);
                    dialogueBox.setProgressing(false);
                }
                if (cameraManager.index == CameraScene.Downstairs)
                {
                    dialogueBox.NextLine();
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
