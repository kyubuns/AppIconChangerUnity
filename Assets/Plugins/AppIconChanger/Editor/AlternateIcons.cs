using System;
using UnityEngine;

namespace AppIconChanger.Editor
{
    [Serializable]
    [CreateAssetMenu]
    public class AlternateIcons : ScriptableObject
    {
        public Icon[] icons;
    }

    [Serializable]
    public class Icon
    {
        public string name;
        public Texture iPhone180Px; // 180x180px
        public Texture iPhone120Px; // 120x120px
        public Texture iPad167Px; // 167x167px
        public Texture iPad152Px; // 152x152px
        public Texture iPad76Px; // 76x76px
    }
}
