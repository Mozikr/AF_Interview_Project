using System;
using UnityEngine;

namespace AFSInterview
{
    [CreateAssetMenu]
    public class Character : ScriptableObject
    {
        [SerializeField] public enum Attributes { Light, Armored, Mechanical };

        [SerializeField] private string type;
        [SerializeField] private Attributes characterAttribute;
        [SerializeField] public int armor_points;
        [SerializeField] public int attack_interval;
        [SerializeField] public int attack_damage;
    }
}
