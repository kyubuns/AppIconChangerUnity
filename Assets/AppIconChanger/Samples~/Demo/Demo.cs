using UnityEngine;
using UnityEngine.UI;

namespace AppIconChanger.Demo
{
    public class Demo : MonoBehaviour
    {
        [SerializeField] private Text statusText = default;

        private string supportsAlternateIcons = "(Empty)";
        private string alternateIconName = "(Empty)";

        public void GetSupportsAlternateIcons()
        {
            supportsAlternateIcons = AppIconChanger.iOS.SupportsAlternateIcons.ToString();
        }

        public void GetAlternateIconName()
        {
            alternateIconName = AppIconChanger.iOS.AlternateIconName ?? "(null)";
        }

        public void ChangeIcon(string iconName)
        {
            AppIconChanger.iOS.SetAlternateIconName(iconName);
        }

        public void ChangeIconToDefault()
        {
            AppIconChanger.iOS.SetAlternateIconName(null);
        }

        public void Update()
        {
            statusText.text = $"supportsAlternateIcons = {supportsAlternateIcons}\nalternateIconName = {alternateIconName}";
        }
    }
}
