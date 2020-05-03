using System;
using UnityEngine;

namespace AppIconChanger.Editor
{
    [Serializable]
    [CreateAssetMenu]
    public class AlternateIcons : ScriptableObject
    {
        public AppIcon[] icons;
    }

    [Serializable]
    public class AppIcon
    {
        public string name;
        public Texture2D iPhone180Px; // 180x180px
        public Texture2D iPhone120Px; // 120x120px
        public Texture2D iPad167Px; // 167x167px
        public Texture2D iPad152Px; // 152x152px
    }
}
