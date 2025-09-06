using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class EnemyData
{
    public string Name;
    public int HP;
    public int Attack;
    public Sprite sprite;
    public int GetCoin;
    public int GetScore;
}
[CreateAssetMenu(fileName = "EnemyInfo", menuName = "Scriptable Objects/EnemyInfo")]
public class EnemyInfo : ScriptableObject
{
    [SerializeField] public List<EnemyData> Enemy;
    public List<EnemyData> Val => Enemy;
}
