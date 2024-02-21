using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AFSInterview
{
    public class FightController : MonoBehaviour
    {
        public List<Unit> army_01;
        public List<Unit> army_02;

        public GameObject Army_01;
        public GameObject Army_02;

        public Button start;
        public TextMeshProUGUI theEnd;

        private bool toggleFlag;
        void Start()
        {
            ResetHP();
            toggleFlag = Random.Range(0, 2) == 0;
            SetupBattle();
        }

        void SetupBattle()
        {
            Army_01.SetActive(true);
            Army_02.SetActive(true);
            UpdateHP();
        }
        public void UpdateHP()
        {
            for (int i = 0; i < army_01.Count; i++)
            {
                if (army_01[i].health_points == 0 )
                {
                    army_01[i].HP.text = army_01[i].Name + " " + "is Dead";
                    army_01[i].body.SetActive(false);
                    army_01.Remove(army_01[i]);
                }
                else
                {
                    army_01[i].HP.text = army_01[i].Name + " " + "HP: " + army_01[i].health_points.ToString();
                    army_01[i].body.SetActive(true);
                }
            }

            for (int i = 0; i < army_02.Count; i++)
            {
                if(army_02[i].health_points == 0)
                {
                    army_02[i].HP.text = army_02[i].Name + " " + "is Dead";
                    army_02[i].body.SetActive(false);
                    army_02.Remove(army_02[i]);
                }
                else
                {
                    army_02[i].HP.text = army_02[i].Name + " " + "HP: " + army_02[i].health_points.ToString();
                    army_02[i].body.SetActive(true);
                }
                
            }
        }

        public void ResetHP()
        {
            for (int i = 0; i < army_01.Count; i++)
            {
                army_01[i].health_points = 100;
            }
            for (int i = 0; i < army_02.Count; i++)
            {
                army_02[i].health_points = 100;
            }
        }

        public void RoundSwitch()
        {
            if (toggleFlag)
            {
                Army_01Turn();
            }
            else
            {
                Army_02Turn();
            }
            toggleFlag = !toggleFlag;
        }
    

        private void Army_01Turn()
        {
            for (int i = 0; i < army_01.Count; i++)
            {
                Unit hero = army_01[i];
                if (hero.CanAttack())
                {
                    int attackEnemyIndex = Random.Range(0, army_02.Count);
                    int damage = hero.characters.attack_damage - army_02[attackEnemyIndex].characters.armor_points;
                    damage = Mathf.Max(0, damage);
                    int health = army_02[attackEnemyIndex].health_points;

                    int newHealth = health - damage;

                    army_02[attackEnemyIndex].health_points = Mathf.Max(0, newHealth);
                    // Logowanie informacji
                    Debug.Log(army_01[i].Name + " atakuje " + army_02[attackEnemyIndex].Name + " za " + damage + " obra¿eñ.");

                    hero.Attack();
                }
                else
                {
                    hero.WaitRound();
                }
            }
            UpdateHP();
            if (army_01.Count ==0)
            {
                start.enabled = false;
                theEnd.gameObject.SetActive(true);
            }
        }

        private void Army_02Turn()
        {
            for (int i = 0; i < army_02.Count; i++)
            {
                Unit hero = army_02[i];
                if (hero.CanAttack())
                {
                    int attackEnemyIndex = Random.Range(0, army_01.Count);
                    int damage = hero.characters.attack_damage - army_01[attackEnemyIndex].characters.armor_points;
                    damage = Mathf.Max(0, damage);
                    int health = army_01[attackEnemyIndex].health_points;

                    int newHealth = health - damage;
                    army_01[attackEnemyIndex].health_points = Mathf.Max(0, newHealth);
                    // Logowanie informacji
                    Debug.Log(army_02[i].Name + " atakuje " + army_01[attackEnemyIndex].Name + " za " + damage + " obra¿eñ.");

                    hero.Attack();
                }
                else
                {
                    hero.WaitRound();
                }
                    
            }
            UpdateHP();
            if (army_02.Count == 0)
            {
                start.enabled = false;
                theEnd.gameObject.SetActive(true);
            }
        }
    }
}
