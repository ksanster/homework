using Game.Model;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerInfo info;
        
        public int HP => info.HP;
    }
}