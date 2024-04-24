using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text CherriesText;
    [SerializeField] public TMP_Text score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            Debug.Log("Collected Cherry, amount collected currently: " + cherries);
            CherriesText.text = "Cherries: " + cherries;
            PlayerPrefs.SetInt("CherriesCollected", cherries);
            score.text = cherries.ToString();
        }
    }

    public int GetScore()
    {
        return PlayerPrefs.GetInt("CherriesCollected");
    }
}
