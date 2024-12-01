using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum AniTimeline
{
    WantEat,
    Eat
}
public class AnimationManager : MonoBehaviour
{
    public PlayableDirector wantEat;
    public PlayableDirector eat;

    public void stopAnimation(AniTimeline type)
    {
        switch (type)
        {
            case AniTimeline.WantEat:
                wantEat.extrapolationMode = DirectorWrapMode.None;
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
            default:
                break;
        }
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
