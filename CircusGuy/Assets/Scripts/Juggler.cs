using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggler : MonoBehaviour
{

    public SpriteRenderer Body;
    public SpriteRenderer Hair;

    public SpriteRenderer Arm;
    public SpriteRenderer Ball;

    public Sprite[] Arms;
    public Sprite[] Balls;

    int AnIndex;
    int CurrentFrame;
    public int FramesPerFrame = 10;

    private void Start()
    {
        Body.color = new Color(Tone(), Tone(), Tone());
        Hair.color = new Color(Tone(), Tone(), Tone());
        Arm.color = new Color(Tone(), Tone(), Tone());
        Ball.color = new Color(Tone(), Tone(), Tone());
       
    }

    float Tone()
    {
        return Random.Range(5, 10) / 10f;
    }

    private void Update()
    {
        ClownAnimation();

    }

    private void ClownAnimation()
    {
        CurrentFrame--;
        if (CurrentFrame < 0)
        {
            CurrentFrame = FramesPerFrame;
            AnIndex++;
        }

       
        if (AnIndex >= Arms.Length)
        {
            AnIndex = 0;
        }
        Arm.sprite = Arms[AnIndex];
        Ball.sprite = Balls[AnIndex];


    }

}
