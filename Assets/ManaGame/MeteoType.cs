using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class MeteoInfo
{
    public GameObject Size;
    public int Score;

}
[CreateAssetMenu(fileName = "MeteoType", menuName = "Scriptable Objects/MeteoType")]
public class MeteoType : ScriptableObject
{
    [SerializeField] private List<MeteoInfo> meteo;
    public List<MeteoInfo> Meteo => meteo;
}
