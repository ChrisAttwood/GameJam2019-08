using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clown : MonoBehaviour
{
    public static Clown instance;
    public Rigidbody2D Rigidbody2D;
    public Sprite[] Left;
    public Sprite[] Right;
    public Sprite[] Up;
    public Sprite[] Down;
    public SpriteRenderer SpriteRenderer;

    public Direction Direction;

    public float MoveMod = 1f;



    int AnIndex;
    int CurrentFrame;
    public int FramesPerFrame = 10;

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

        switch (Direction)
        {
            case Direction.Up:
                if (AnIndex >= Up.Length)
                {
                    AnIndex = 0;
                }
                SpriteRenderer.sprite = Up[AnIndex];
                break;
            case Direction.Left:
                if (AnIndex >= Left.Length)
                {
                    AnIndex = 0;
                }
                SpriteRenderer.sprite = Left[AnIndex];
                break;
            case Direction.Down:
                if (AnIndex >= Down.Length)
                {
                    AnIndex = 0;
                }
                SpriteRenderer.sprite = Down[AnIndex];
                break;
            case Direction.Right:
                if (AnIndex >= Right.Length)
                {
                    AnIndex = 0;
                }
                SpriteRenderer.sprite = Right[AnIndex];
                break;

        }


    }



    private void Awake()
    {
        instance = this;
    }

   
}
