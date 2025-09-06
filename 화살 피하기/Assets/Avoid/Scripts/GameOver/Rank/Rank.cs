using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Rank", menuName = "Scriptable Objects/Rank")]
public class Rank : ScriptableObject
{
    public List<float> time;
}
