using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

namespace AppIconChanger.Editor
{
    public static class PostProcessor
    {
        [PostProcessBuild]
        public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS) return;

            var alternateIconsGuidList = AssetDatabase.FindAssets($"t:{nameof(AlternateIcons)}");
            var appIcons = new List<AppIcon>();
            foreach (var alternateIconsGuid in alternateIconsGuidList)
            {
                var path = AssetDatabase.GUIDToAssetPath(alternateIconsGuid);
                var alternateIcons = AssetDatabase.LoadAssetAtPath<AlternateIcons>(path);
                appIcons.AddRange(alternateIcons.icons);
            }

            UpdateInfoPlist(pathToBuiltProject, appIcons.ToArray());
        }

        private static void UpdateInfoPlist(string pathToBuiltProject, AppIcon[] appIcons)
        {
            var plistPath = Path.Combine(pathToBuiltProject, "Info.plist");
            var plist = new PlistDocument();
            plist.ReadFromFile(plistPath);

            {
                var bundleIcons = plist.root.CreateDict("CFBundleIcons");
                {
                    var bundlePrimaryIcon = bundleIcons.CreateDict("CFBundlePrimaryIcon");

                    var bundleIconFiles = bundlePrimaryIcon.CreateArray("CFBundleIconFiles");
                    bundleIconFiles.AddString("");

                    bundlePrimaryIcon.SetBoolean("UIPrerenderedIcon", false);
                }
                {
                    var bundleAlternateIcons = bundleIcons.CreateDict("CFBundleAlternateIcons");

                    foreach (var appIcon in appIcons)
                    {
                        var appDict = bundleAlternateIcons.CreateDict(appIcon.name);
                        var bundleIconFiles = appDict.CreateArray("CFBundleIconFiles");
                        bundleIconFiles.AddString(appIcon.name);
                    }
                }
            }

            plist.WriteToFile(plistPath);
        }
    }
}
