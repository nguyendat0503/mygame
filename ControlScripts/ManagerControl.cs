using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerControl : MonoBehaviour
{
    public static ManagerControl instance;

    private const string HIGH_SCORE = "Hight score";

    void GameStartFirstTime()
    {
        if (!PlayerPrefs.HasKey("GameStartFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("GameStartFirstTime", 0);
        }
    }
    void Awake()
    {
        MakeSingleInstance();
        GameStartFirstTime();
    }
    void MakeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetHightScore(float score)
    {
        int x = (int)score;
        PlayerPrefs.SetFloat(HIGH_SCORE, x);
    }
    public float GetHightScore()
    {
        return PlayerPrefs.GetFloat(HIGH_SCORE);
    }

}
