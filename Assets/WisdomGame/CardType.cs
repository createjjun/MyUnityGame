using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CardType", menuName = "Scriptable Objects/CardType")]
public class CardType : ScriptableObject
{
    [SerializeField] private List<Sprite> sp;
    public List<Sprite> Sp { get { return sp; } private set { sp = value; } }

}
