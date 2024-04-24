using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using System;
using TMPro;
using TMPro.EditorUtilities;

public class MainMenu : MonoBehaviour
{
    [SerializeField] List<TMP_StyleEditor> text;
    string playerName, scene = "MainGameScene";
    [SerializeField] TMP_InputField inputPlayerName;



    public void SetPlayerName()
    {
        playerName = inputPlayerName.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        Debug.Log(playerName);
    }
    public void EasyMap()
    {
        scene = "MainGameScene";
    }

    private void MediumMap()
    {
        scene = "";
    }

    public void HardMap()
    {
        scene = "HardGameScene";
    }

    public void PlayGame()
    {
        Debug.Log("Starting the game ( Switching Scenes");
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Debug.Log("Game was quit");
        Application.Quit();
    }

    /*public int GetCharacterSkin()
    {
        return PlayerPrefs.GetInt(skinChoice);
    }*/
}
