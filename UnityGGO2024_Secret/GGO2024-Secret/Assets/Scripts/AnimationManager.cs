using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum AniTimeline
{
    WantEat,
    Eat,
    Love
}
public class AnimationManager : MonoBehaviour
{
    public PlayableDirector wantEat;
    public PlayableDirector eat;
    public PlayableDirector love;
    public GameObject loveObj;

    public void stopAnimation(AniTimeline type)
    {
        switch (type)
        {
            case AniTimeline.WantEat:
                wantEat.extrapolationMode = DirectorWrapMode.Hold;
                wantEat.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
    public void playAnimation(AniTimeline type)
    {
        print("here" + type);
        switch (type)
        {
            case AniTimeline.WantEat:
                wantEat.Play();
                break;
            case AniTimeline.Eat:
                eat.Play();
                break;
            case AniTimeline.Love:
                love.Play();
                break;
            default:
                break;
        }
    }

    public void OnEatStopped()
    {
        loveObj.SetActive(true);
        playAnimation(AniTimeline.Love);
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
