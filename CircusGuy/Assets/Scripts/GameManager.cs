using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;



    public Level[] Levels;

    public Maze Maze;

    public GameObject WinCanvas;
    public GameObject LoseCanvas;
    public GameObject WinGameCanvas;

    bool MovingNext;

    public bool LevelEnded;

    // Start is called before the first frame update
    void Awake()
    {
        MovingNext = false;
        instance = this;
        GameFileManager.Load();
        if (GameFileManager.GameFile.CurrentLevel >= Levels.Length)
        {
            GameFileManager.GameFile.CurrentLevel = 0;
        }
        if(GameFileManager.GameFile.CurrentLevel == 0)
        {
            GameFileManager.GameFile.CurrentLevel = 0;
            GameFileManager.GameFile.CurrentScore = 0;
        }
        GameFileManager.Save();
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        if(MovingNext && Input.GetKeyDown(KeyCode.Space))
        {
            MovingNext = false;
            SceneManager.LoadScene("Level1");
        }
    }

    public Level CurrentLevel()
    {
        return Levels[GameFileManager.GameFile.CurrentLevel];
    }

    private void Start()
    {
        GameFileManager.Load();
        MainCanvas.instance.Score = GameFileManager.GameFile.CurrentScore;
        GameFileManager.Save();

        Maze.Create(Levels[GameFileManager.GameFile.CurrentLevel]);
    }


    public void EndLevel()
    {
        if (LevelEnded) return;

        LevelEnded = true;

        GameFileManager.Load();
        GameFileManager.GameFile.CurrentLevel++;
        GameFileManager.GameFile.CurrentScore += MainCanvas.instance.Score;
        MainCanvas.instance.Score = 0;
        if (GameFileManager.GameFile.CurrentLevel >= Levels.Length)
        {
            WinGameCanvas.SetActive(true);
            GameFileManager.GameFile.CurrentLevel = 0;
            GameFileManager.Save();
        }
        else
        {
            GameFileManager.Save();
            WinCanvas.SetActive(true);


            Invoke("NextScene", 1f);
        }




    }

    public void GameOver()
    {
        LoseCanvas.SetActive(true);
        Invoke("MenuScene", 3f);
    }
    
    void NextScene()
    {
        MovingNext = true;
        
    }

    void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }



}
