using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class PlayerDataContainer : ScriptableObject
{
    public PlayerOrder playerOrder;
    public string characterName;
    public Sprite characterImage;
    public SpecialAttacks specialAttack;
}


