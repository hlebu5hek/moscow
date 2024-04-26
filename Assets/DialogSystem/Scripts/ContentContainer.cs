using System;
using UnityEngine;

namespace DialogSystem.Scripts
{
    [CreateAssetMenu(menuName = nameof(DialogSystem) + "/" + nameof(Scripts) + "/" + nameof(ContentContainer),
        fileName = nameof(ContentContainer))]
    public class ContentContainer : ScriptableObject
    {
        public TextData[] texts;
    }

    [Serializable]
    public class TextData
    {
        public string text;
        public int nextIndex = -1; 
        [Range(0.1f, 3f)]public float delayTime = 1;
        public bool player = true;
        public TextVariant[] variants;
    }
    
    [Serializable]
    public class TextVariant
    {
        public string text;
        public int toIndex;
    }
}