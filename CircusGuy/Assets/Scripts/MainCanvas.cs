using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;


    public TMP_Text ScoreText;
    public TMP_Text TimeText;
    public TMP_Text BalloonText;

    public int Score = 0;

    public int BalloonCount;
    public int TotalBaloons;


    Stopwatch sw;

    System.TimeSpan limit;

    

    private void Start()
    {

        limit = new System.TimeSpan(0, 3, 0);

        sw = new Stopwatch();
        sw.Start();
        UpdateScore(0);
    }

    public void UpdateScore(int Amount)
    {
        Score+= Amount;
        ScoreText.text = string.Format("Score: {0}", Score);
    }

    public void RemoveBaloon()
    {
        BalloonCount++;
        DisplayBaloons();
        if (BalloonCount>= GameManager.instance.CurrentLevel().BalloonsRequired)
        {
            GameManager.instance.EndLevel();
        }

       
    }

    public void DisplayBaloons()
    {
        BalloonText.text = string.Format("{0}/{1}", BalloonCount, GameManager.instance.CurrentLevel().BalloonsRequired);
    }

    private void Update()
    {
        if (!GameManager.instance.LevelEnded)
        {
            if (sw.Elapsed > limit)
            {
                GameManager.instance.GameOver();
            }
            else
            {
                TimeText.text = (limit - sw.Elapsed).ToString("mm':'ss");
            }

        }
    }

    private void Awake()
    {
        instance = this;
    }

     

  
    

}
