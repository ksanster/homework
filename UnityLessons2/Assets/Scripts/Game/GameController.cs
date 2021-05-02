using Game.UI;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private UIManager ui;
        
        [SerializeField]
        private Player player;


        private void Awake()
        {
            ui.Player = player;
        }
    }
}