using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public PlayerOrder playerOrder;
    public CharacterStats playerStats;
    public Image characterImage;
    public RectTransform currentHealthBar, maxHealthBar;
    public RectTransform currentSpecialBar, maxSpecialBar;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        DisplayPlayerUI();

    }
    void LateUpdate()
    {
        PlayerHealthBarUpdate();

        PlayerSpecialBarUpdate();
    }

    private void DisplayPlayerUI()
    {
        if (playerStats)
        {
            if (playerStats.gameObject.activeSelf)
            {
                characterImage.gameObject.SetActive(true);
            }
            else
            {
                characterImage.gameObject.SetActive(false);
            }
        }
        else
        {
            characterImage.gameObject.SetActive(false);
        }
    }

    public void SetCharacterImage(Image image)
    {
        characterImage = image;
    }

    private void PlayerHealthBarUpdate()
    {
        if (playerStats && maxHealthBar)
        {
            float width = (playerStats.currentHealth * maxHealthBar.localScale.x) / playerStats.maxHealth;

            if(width < 0)
            {
                width = 0;
            }
            else if (width > maxHealthBar.localScale.x)
            {
                width = maxHealthBar.localScale.x;
            }

            if (currentHealthBar)
            {
                currentHealthBar.localScale = new Vector2(width, currentHealthBar.localScale.y);
            }
        }
    }

    private void PlayerSpecialBarUpdate()
    {
        if (playerStats && maxSpecialBar)
        {
            float width = (playerStats.currentSpecialTimer * maxSpecialBar.localScale.x) / playerStats.maxSpecialTimer;    // Replace with special timer

            if (width <= 0)
            {
                width = 0;
            }
            else if (width >= maxSpecialBar.localScale.x)
            {
                width = maxSpecialBar.localScale.x;
            }

            if (currentSpecialBar)
            {
                currentSpecialBar.localScale = new Vector2(width, currentSpecialBar.localScale.y);
            }
        }
    }
}
