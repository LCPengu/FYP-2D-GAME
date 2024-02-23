using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text CherriesText;
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            Log("Collected Cherry, amount collected currently: " + cherries);
            CherriesText.text = "Cherries: " + cherries;
        }
    }

    private void Log(string msg)
    {
        Debug.Log(msg);
    }
}
