using System;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace AppIconChanger.Editor
{
    [Serializable]
    [CreateAssetMenu(menuName = "AppIconChanger/AlternateIcon")]
    public class AlternateIcon : ScriptableObject
    {
        public string iconName;
        public AlternateIconType type;

        public Texture2D source;
        public Texture2D iPhoneNotification40px;
        public Texture2D iPhoneNotification60px;
        public Texture2D iPhoneSettings58px;
        public Texture2D iPhoneSettings87px;
        public Texture2D iPhoneSpotlight80px;
        public Texture2D iPhoneSpotlight120px;
        public Texture2D iPhoneApp120px;
        public Texture2D iPhoneApp180px;
        public Texture2D iPadNotifications20px;
        public Texture2D iPadNotifications40px;
        public Texture2D iPadSettings29px;
        public Texture2D iPadSettings58px;
        public Texture2D iPadSpotlight40px;
        public Texture2D iPadSpotlight80px;
        public Texture2D iPadApp76px;
        public Texture2D iPadApp152px;
        public Texture2D iPadProApp167px;
        public Texture2D appStore1024px;
    }

    public enum AlternateIconType
    {
        AutoGenerate,
        Manual,
    }
}
