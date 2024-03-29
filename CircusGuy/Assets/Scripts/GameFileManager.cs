﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class GameFileManager {

    public static GameFile GameFile;

    public static void Save()
    {
        Save(GameFile, "CircusGuy");
     
    }

    public static void Load()
    {

        if (!Exists("CircusGuy"))
        {
            GameFile = new GameFile();
            GameFile.HighScore = 0;
            Save();
        }

        GameFile = Load<GameFile>("CircusGuy");
    }


    public static void Save<T>(T data,string name)
    {

        BinaryFormatter bf = GetBinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/" + name + ".game");
        bf.Serialize(file, data);
        file.Close();
    }

    public static T Load<T>(string name)
    {
        BinaryFormatter bf = GetBinaryFormatter();

        FileStream file = File.OpenRead(Application.persistentDataPath + "/" + name + ".game");
        T data = (T)bf.Deserialize(file);
        file.Close();

        return data;
    }

    public static void Delete()
    {
        Delete("CircusGuy");
    }

    public static void Delete(string name)
    {

        File.Delete(Application.persistentDataPath + "/" + name + ".game");

    }


    public static bool Exists(string name)
    {
        return File.Exists(Application.persistentDataPath + "/" + name + ".game");
    }

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter bf = new BinaryFormatter();

        SurrogateSelector surrogateSelector = new SurrogateSelector();

      

        bf.SurrogateSelector = surrogateSelector;

        return bf;
    }
}
