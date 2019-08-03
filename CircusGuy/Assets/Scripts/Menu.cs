using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameFileManager.Load();
        GameFileManager.GameFile.CurrentLevel = 0;
        
        GameFileManager.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
