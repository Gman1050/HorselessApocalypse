using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public PlayerOrder playerOrder;
    public CharacterStats playerStats;
    public Image characterImage;
    public Rect healthBar, specialBar;

    private const float barWidth = 230.0f;

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
        float width = (playerStats.currentHealth * barWidth) / playerStats.maxHealth;
        healthBar = new Rect(healthBar.x, healthBar.y, width, healthBar.height);

    }

    private void PlayerSpecialBarUpdate()
    {
        float width = (playerStats.currentHealth * barWidth) / playerStats.maxHealth;    // Replace with special timer
        specialBar = new Rect(specialBar.x, specialBar.y, width, specialBar.height);
    }
}
