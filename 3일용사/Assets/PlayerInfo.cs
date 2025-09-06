using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]                 
public class AbilityData
{
    public string Ability;               
    public int value;                
}
[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Scriptable Objects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    [SerializeField] public List<AbilityData> val;
    public List<AbilityData> Val => val;
    public void Add(int i, int amount)
    {
        val[i].value += amount;
    }
    
}
