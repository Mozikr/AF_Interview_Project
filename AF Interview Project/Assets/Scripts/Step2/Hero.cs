using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AFSInterview
{
    [Serializable]
    public class Hero
    {
        public string Name;
        public Character characters;
        public GameObject body;
        public TextMeshProUGUI HP;
    }
}
