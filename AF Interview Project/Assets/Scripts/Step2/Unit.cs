using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AFSInterview
{
    [Serializable]
    public class Unit
    {
        public string Name;
        public Character characters;
        public GameObject body;
        public TextMeshProUGUI HP;
        private int roundsToWait = 0;
        public int health_points = 100;

        public bool CanAttack()
        {
            return roundsToWait <= 0 && health_points >= 0;
        }

        public void WaitRound() 
        {
            roundsToWait--;
        }

        public void Attack()
        {
            roundsToWait = characters.attack_interval-1;
        }
    }
}
