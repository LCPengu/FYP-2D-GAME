using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Info : MonoBehaviour
{
    public int skinInt;
    string playerName = "No Name", skinChoice;
    [SerializeField] TMP_InputField inputPlayerName;

    void Awake()
    {
        if (PlayerPrefs.GetString("playerName") == null)
        {
            PlayerPrefs.SetString("playerName", "No Name");
        }
    }
    public void SetPlayerName()
    {
        playerName = inputPlayerName.text;
        PlayerPrefs.SetString("playerName", playerName);
        Debug.Log(playerName);

    }

    public void CharacterToBlue()
    {
        PlayerPrefs.SetInt(skinChoice, 1);
        CharacterChecker();
    }

    public void CharacterToPink()
    {
        PlayerPrefs.SetInt(skinChoice, 2);
        CharacterChecker();
    }

    public void CharacterToWhite()
    {
        PlayerPrefs.SetInt(skinChoice, 3);
        CharacterChecker();
    }

    public void CharacterToGreen()
    {
        PlayerPrefs.SetInt(skinChoice, 4);
        CharacterChecker();
    }

    public int GetSkinInt()
    {
        return PlayerPrefs.GetInt(skinChoice);
    }

    public string GetPlayerName()
    {
        return PlayerPrefs.GetString("playerName");
    }

    public void CharacterChecker()
    {
        Debug.Log("Character skin: " + PlayerPrefs.GetInt(skinChoice));
    }

}
