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


        if (Rigidbody2D.velocity.x > 0)
        {
            if (AnIndex >= Right.Length)
            {
                AnIndex = 0;
            }
            SpriteRenderer.sprite = Right[AnIndex];
        }
        else if (Rigidbody2D.velocity.x < 0)
        {
            if (AnIndex >= Left.Length)
            {
                AnIndex = 0;
            }
            SpriteRenderer.sprite = Left[AnIndex];
        }
        else if (Rigidbody2D.velocity.y > 0)
        {
            if (AnIndex >= Up.Length)
            {
                AnIndex = 0;
            }
            SpriteRenderer.sprite = Up[AnIndex];
        }
        else if (Rigidbody2D.velocity.y < 0)
        {
            if (AnIndex >= Down.Length)
            {
                AnIndex = 0;
            }
            SpriteRenderer.sprite = Down[AnIndex];
        }
    }

    private void Awake()
    {
        instance = this;
    }

  
}
