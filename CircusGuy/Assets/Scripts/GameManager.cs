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

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        GameFileManager.Load();
        if (GameFileManager.GameFile.CurrentLevel >= Levels.Length)
        {
            GameFileManager.GameFile.CurrentLevel = 0;
        }

        MainCanvas.instance.Score = GameFileManager.GameFile.CurrentScore;
        GameFileManager.Save();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public Level CurrentLevel()
    {
        return Levels[GameFileManager.GameFile.CurrentLevel];
    }

    private void Start()
    {
        GameFileManager.Load();

        Maze.Create(Levels[GameFileManager.GameFile.CurrentLevel]);
    }


    public void EndLevel()
    {
        GameFileManager.GameFile.CurrentLevel++;
        GameFileManager.GameFile.CurrentScore += MainCanvas.instance.Score;
        if (GameFileManager.GameFile.CurrentLevel >= Levels.Length)
        {
            GameFileManager.GameFile.CurrentLevel = 0;
        }

        GameFileManager.Save();
        WinCanvas.SetActive(true);


        Invoke("NextScene", 3f);

    }

    public void GameOver()
    {
        LoseCanvas.SetActive(true);
        Invoke("MenuScene", 3f);
    }
    
    void NextScene()
    {
        SceneManager.LoadScene("Level1");
    }

    void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

}
