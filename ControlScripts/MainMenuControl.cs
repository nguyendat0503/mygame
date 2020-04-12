using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField]
    private Text hightScoreText;

    [SerializeField]
    private GameObject hightScorePanel;

    void Awake()
    {
        hightScoreText.text = "" + ManagerControl.instance.GetHightScore();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
