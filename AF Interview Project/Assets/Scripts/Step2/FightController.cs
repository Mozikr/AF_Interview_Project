using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AFSInterview
{
    public class FightController : MonoBehaviour
    {
        public Hero[] army_01;
        public Hero[] army_02;

        public GameObject Army_01;
        public GameObject Army_02;

        public Button start;
        public TextMeshProUGUI theEnd;

        private bool toggleFlag = false;
        void Start()
        {
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
            for (int i = 0; i < army_01.Length; i++)
            {
                if (army_01[i].characters.health_points == 0 )
                {
                    army_01[i].HP.text = army_01[i].Name + " " + "is Dead";
                    army_01[i].body.SetActive(false);
                }
                else
                {
                    army_01[i].HP.text = army_01[i].Name + " " + "HP: " + army_01[i].characters.health_points.ToString();
                    army_01[i].body.SetActive(true);
                }
            }

            for (int i = 0; i < army_02.Length; i++)
            {
                if(army_02[i].characters.health_points == 0)
                {
                    army_02[i].HP.text = army_02[i].Name + " " + "is Dead";
                    army_02[i].body.SetActive(false);
                }
                else
                {
                    army_02[i].HP.text = army_02[i].Name + " " + "HP: " + army_02[i].characters.health_points.ToString();
                    army_02[i].body.SetActive(true);
                }
                
            }
        }

        private bool IsDeadArmy(Hero[] army)
        {
            int counter = 0;
            foreach(Hero armyCharacter in army)
            {
                if(armyCharacter.characters.health_points == 0)
                {
                    counter++;
                }
            }

            return counter == army.Length;
        }

        public void ResetHP()
        {
            for (int i = 0; i < army_01.Length; i++)
            {
                army_01[i].characters.health_points = 100;
            }
            for (int i = 0; i < army_02.Length; i++)
            {
                army_02[i].characters.health_points = 100;
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
            for (int i = 0; i < army_01.Length; i++)
            {
                if (army_02.Length > 0)
                {
                    int attackEnemyIndex = Random.Range(0, army_02.Length);
                    int damage = army_01[i].characters.attack_damage;
                    int health = army_02[attackEnemyIndex].characters.health_points;

                    int newHealth = health - damage;

                    army_02[attackEnemyIndex].characters.health_points = Mathf.Max(0, newHealth);

                    Debug.Log(army_01[i].Name + " atakuje " + army_02[attackEnemyIndex].Name + " za " + damage + " obra¿eñ.");

                    if (army_02[attackEnemyIndex].characters.health_points <= 0)
                    {
                        Debug.Log(army_02[attackEnemyIndex].Name + " zosta³ pokonany.");
                    }
                }
            }

            UpdateHP();
            if (IsDeadArmy(army_02))
            {
                Debug.Log("Koniec armia 2 zabita");
                start.enabled = false;
                theEnd.gameObject.SetActive(true);
            }
        }

        private void Army_02Turn()
        {
            for (int i = 0; i < army_02.Length; i++)
            {
                if (army_01.Length > 0)
                {
                    int attackEnemyIndex = Random.Range(0, army_01.Length);
                    int damage = army_02[i].characters.attack_damage;
                    int health = army_01[attackEnemyIndex].characters.health_points;

                    int newHealth = health - damage;

                    army_01[attackEnemyIndex].characters.health_points = Mathf.Max(0, newHealth);

                    Debug.Log(army_02[i].Name + " atakuje " + army_01[attackEnemyIndex].Name + " za " + damage + " obra¿eñ.");

                    if (army_01[attackEnemyIndex].characters.health_points <= 0)
                    {
                        Debug.Log(army_01[attackEnemyIndex].Name + " zosta³ pokonany.");
                    }
                }
            }

            UpdateHP();
            if (IsDeadArmy(army_01))
            {
                Debug.Log("Koniec armia 1 zabita");
                start.enabled = false;
                theEnd.gameObject.SetActive(true);
            }
        }
    }
}
