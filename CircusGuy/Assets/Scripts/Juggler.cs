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

    public AudioClip AudioClip;


    public Color[] Colors;


    private void Start()
    {
        //Body.color = new Color(Tone(), Tone(), Tone());
        //Hair.color = new Color(Tone(), Tone(), Tone());
        //Arm.color = new Color(Tone(), Tone(), Tone());
        //Ball.color = new Color(Tone(), Tone(), Tone());
        Body.color = Colors[Random.Range(0, Colors.Length)];
        Hair.color = Colors[Random.Range(0, Colors.Length)];
        Arm.color = Colors[Random.Range(0, Colors.Length)];
        Ball.color = Colors[Random.Range(0, Colors.Length)];

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


    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        Barrel.instance.Spin();
        AudioEffects.instance.PlayEffect(AudioClip, 1f, 1f);
       
    }
}
