using UnityEngine;

namespace AppIconChanger.Demo
{
    public class Demo : MonoBehaviour
    {
        private string supportsAlternateIcons = "(Empty)";
        private string alternateIconName = "(Empty)";

        public void OnGUI()
        {
            GUI.TextArea(new Rect(10, 10, 300, 50), $"supportsAlternateIcons = {supportsAlternateIcons}");
            GUI.TextArea(new Rect(10, 60, 300, 50), $"alternateIconName = {alternateIconName}");

            if (GUI.Button(new Rect(10, 120, 300, 100), "Get SupportsAlternateIcons"))
            {
                supportsAlternateIcons = iOS.SupportsAlternateIcons.ToString();
            }

            if (GUI.Button(new Rect(10, 220, 300, 100), "Get AlternateIconName"))
            {
                alternateIconName = iOS.AlternateIconName.ToString();
            }

            if (GUI.Button(new Rect(10, 320, 300, 100), "Change Icon Red"))
            {
                iOS.SetAlternateIconName("demo_red");
            }

            if (GUI.Button(new Rect(10, 420, 300, 100), "Change Icon Green"))
            {
                iOS.SetAlternateIconName("demo_green");
            }

            if (GUI.Button(new Rect(10, 520, 300, 100), "Change Icon Blue"))
            {
                iOS.SetAlternateIconName("demo_blue");
            }
        }
    }
}
