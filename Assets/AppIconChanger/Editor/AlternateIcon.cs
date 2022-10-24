using System;
using System.IO;
using UnityEngine;
using UnityEditor;
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

        [MenuItem("Assets/Create/AppIconChanger/AlternateIcon from Selection...")]
        private static void CreateAlternateIconFromSelection() {
            Texture2D[] selectedTexture2Ds = GetFilteredSelection();
            foreach (Texture2D tex in selectedTexture2Ds) {
                string assetPath = AssetDatabase.GetAssetPath(tex);
                if (string.IsNullOrEmpty(assetPath)) {
                    continue;
                }

                string directory = Path.GetDirectoryName(assetPath);
                string filename = Path.GetFileNameWithoutExtension(assetPath);
                string basePath = Path.Combine(directory, $"{filename}.asset");

                bool overwrite = true;
                if (File.Exists(basePath)) {
                    int result = EditorUtility.DisplayDialogComplex("Warning", $"A file already exists at\n\n{basePath}\n\nWhat do you want to do?", "Overwrite", "Generate Unique Name", "Skip");
                    if (result == 2) {
                        continue;
                    }
                    overwrite = (result == 0);
                }
                
                if (!overwrite) {
                    basePath = AssetDatabase.GenerateUniqueAssetPath(basePath);
                }

                AlternateIcon icon = ScriptableObject.CreateInstance<AlternateIcon>();
                icon.iconName = filename;
                icon.source = tex;
                if (overwrite) {
                    AssetDatabase.DeleteAsset(basePath);
                }
                AssetDatabase.CreateAsset(icon, basePath);
            }
            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        }

        [MenuItem("Assets/Create/AppIconChanger/AlternateIcon from Selection...", isValidateFunction: true)]
        private static bool CanCreateAlternateIconFromSelection() {
            return GetFilteredSelection().Length > 0;
        }

        private static Texture2D[] GetFilteredSelection() {
            return Selection.GetFiltered<Texture2D>(SelectionMode.Assets | SelectionMode.TopLevel);
        }
    }

    public enum AlternateIconType
    {
        AutoGenerate,
        Manual,
    }
}
