using Game.Model;
using UnityEngine;

namespace Game.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private GUISkin skin;
        
        [SerializeField]
        private Texture2D progressBack;
        [SerializeField]
        private Texture2D progressFront;
        
        private Player player;
        private float hp;
        
        public Player Player
        {
            set => player = value;
        }
        
        private void HP(Rect position, float value)
        {
            GUI.DrawTexture(position, progressBack, ScaleMode.StretchToFill);
            var frontRect = new Rect(position.x, position.y, position.width * value, position.height);
            GUI.DrawTexture(frontRect, progressFront, ScaleMode.ScaleAndCrop);
        }

        private void OnGUI()
        {
            HP(new Rect(10, 10, 200, 20), (float)player.HP / PlayerInfo.MaxHP);
        }
    }
}