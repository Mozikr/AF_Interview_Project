using System;
using UnityEngine;

namespace AFSInterview
{
    [CreateAssetMenu]
    public class Character : ScriptableObject
    {
        [SerializeField] private string type;
        [SerializeField] private int health_points;
        [SerializeField] private int armor_points;
        [SerializeField] private int attack_interval;
        [SerializeField] private int attack_damage;
    }
}
