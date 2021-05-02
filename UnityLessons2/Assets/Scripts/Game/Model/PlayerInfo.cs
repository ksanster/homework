using System.Collections.Generic;
using UnityEngine;

namespace Game.Model
{
    [CreateAssetMenu(fileName = "PlayerInfo", menuName = "Player Info")]
    public class PlayerInfo : ScriptableObject
    {
        public const int MaxHP = 100;
        
        [SerializeField]
        private int hp;
        [SerializeField]
        private List<InventoryItem> inventory = new List<InventoryItem>();
        
        public int HP => hp;
    }
}