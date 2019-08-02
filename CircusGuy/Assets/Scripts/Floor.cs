using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    public int SizeX = 64;
    public int SizeY = 64;

    public GameObject[] Tiles;

    void Start()
    {
        Create();
    }


    public void Create()
    {
        for(int x = -SizeX; x< SizeX; x++)
        {
            for (int y = -SizeY; y < SizeY; y++)
            {

                var tile = Instantiate(Tiles[Random.Range(0, Tiles.Length)], this.transform);
                tile.transform.position = new Vector2(x, y);
            }
        }

    }

}
