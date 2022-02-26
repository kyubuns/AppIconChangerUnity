using System.Runtime.InteropServices;

namespace AppIconChanger
{
    public static class iOS
    {
#if UNITY_IOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern bool _SupportsAlternateIcons();

        [DllImport("__Internal")]
        private static extern string _AlternateIconName();

        [DllImport("__Internal")]
        private static extern void _SetAlternateIconName(string iconName);
#else
        private static bool _SupportsAlternateIcons()
        {
            UnityEngine.Debug.Log("SupportsAlternateIcons is not supported on this device.");
            return false;
        }

        private static string _AlternateIconName()
        {
            UnityEngine.Debug.Log("AlternateIconName is not supported on this device.");
            return string.Empty;
        }

        private static void _SetAlternateIconName(string iconName)
        {
            UnityEngine.Debug.Log("SetAlternateIconName is not supported on this device.");
        }
#endif

        public static bool SupportsAlternateIcons => _SupportsAlternateIcons();

        public static string AlternateIconName => _AlternateIconName();

        public static void SetAlternateIconName(string iconName)
        {
            _SetAlternateIconName(iconName);
        }
    }
}
