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
        [SerializeField] public int health_points;
        [SerializeField] private int armor_points;
        [SerializeField] private int attack_interval;
        [SerializeField] public int attack_damage;
    }
}
