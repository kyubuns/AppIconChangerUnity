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
            supportsAlternateIcons = iOS.SupportsAlternateIcons.ToString();
        }

        public void GetAlternateIconName()
        {
            alternateIconName = iOS.AlternateIconName ?? "(null)";
        }

        public void ChangeIcon(string iconName)
        {
            iOS.SetAlternateIconName(iconName);
        }

        public void ChangeIconToDefault()
        {
            iOS.SetAlternateIconName(null);
        }

        public void Update()
        {
            statusText.text = $"supportsAlternateIcons = {supportsAlternateIcons}\nalternateIconName = {alternateIconName}";
        }
    }
}
