using UnityEngine;

namespace DialogSystem.Scripts
{
    [CreateAssetMenu(menuName = nameof(DialogSystem) + "/" + nameof(Scripts) + "/" + nameof(DialogColors),
        fileName = nameof(DialogColors))]
    public class DialogColors : ScriptableObject
    {
        public Color playerColor;
        public Color aliveColor;
        public Color additionColor;
    }
}
