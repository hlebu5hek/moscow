using System;
using UnityEngine;

namespace Smooth_Translate.Scripts
{
    [CreateAssetMenu(menuName = nameof(Smooth_Translate) + "/" + nameof(Scripts) + "/" + nameof(DaysInfo),
        fileName = nameof(DaysInfo))]
    public class DaysInfo : ScriptableObject
    {
        public DayInfo[] days;
    }

    [Serializable]
    public class DayInfo
    {
        public string dayName;
        public string dayDescription;
    }
}