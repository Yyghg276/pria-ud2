using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Behaviour : MonoBehaviour
{

    private int itemsCollected = 0;
    private int playerHP = 10;

    public int max_Items = 8;
    public TMP_Text health_Text;
    public TMP_Text item_Text;
    public TMP_Text progress_Text;

    public Button win_Button;
    public Button LossButton;

    public int Items
    {
        get { return itemsCollected; }
        set
        {
            itemsCollected = value;

            item_Text.text = "ITEMS COLLECTED: " + Items;
            if (itemsCollected >= max_Items)
            {
                UpdateScene ("YOU'VE FOUND ALL THE ITEMS!");
                win_Button.gameObject.SetActive(true);
            }
            else
            {
                progress_Text.text = "ITEM FOUND, ONLY " + (max_Items - itemsCollected) + " MORE!";
            }
        }
    }
    public int HP
    {
        get { return playerHP; }
        set
        {
            playerHP = value;

            health_Text.text = "PLAYER HEALTH: " + HP;
            if (playerHP <= 0)
            {
                UpdateScene ("YOU WANT ANOTHER LIFE WITH THAT?");
                LossButton.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                progress_Text.text = "OUCH... THAT'S GOT HURT.";
            }
            Debug.LogFormat("Lives: {0}", playerHP);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }



    void Start()
    {
        item_Text.text += itemsCollected;
        health_Text.text += playerHP;
    }

    void Update()
    {
        
    }

    public void UpdateScene(string updatedText)
    {
        progress_Text.text = updatedText;
        Time.timeScale = 0f;
    }
}
