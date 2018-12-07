using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Gun",menuName ="Gun")]
public class Gun : ScriptableObject {

    public string Gunname;
    public float CurrentUpGradeLevel;
    public float  Damage;
    public bool Locked;
    public int NextUpGradeCoinAmount;
    public bool CurrentActived;
}
