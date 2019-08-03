using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
   
    //public GameObject[] Items;
    //public Sprite[] Maps;


    private void Start()
    {
      //  Create();
    }






    public void Create(Level level)
    {

        int bCount = 0;
        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 32; y++)
            {
                for (int i = 0; i < level.Maps.Length; i++)
                {
                    if (level.Maps[i].texture.GetPixel(x, y).a > 0f)
                    {
                        if (i == level.BalloonLayer)
                        {
                            bCount++;
                        }

                        var p = Instantiate(level.Items[i], transform);
                        p.transform.position = new Vector2(x - 16, y - 16);
                    }
                }
            }
        }

        MainCanvas.instance.TotalBaloons = bCount;
        MainCanvas.instance.DisplayBaloons();
    }
}
