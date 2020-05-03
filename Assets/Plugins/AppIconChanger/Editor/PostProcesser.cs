using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace AppIconChanger.Editor
{
    public static class PostProcessor
    {
        [PostProcessBuild]
        public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target != BuildTarget.iOS) return;

            var appIconDirectoryPath = Path.Combine(pathToBuiltProject, "AppIconChanger");
            if (Directory.Exists(appIconDirectoryPath)) Directory.Delete(appIconDirectoryPath, true);

            var alternateIconsGuidList = AssetDatabase.FindAssets($"t:{nameof(AlternateIcons)}");
            var appIcons = new List<AppIcon>();
            foreach (var alternateIconsGuid in alternateIconsGuidList)
            {
                var path = AssetDatabase.GUIDToAssetPath(alternateIconsGuid);
                var alternateIcons = AssetDatabase.LoadAssetAtPath<AlternateIcons>(path);
                appIcons.AddRange(alternateIcons.icons);
            }

            if (appIcons.Count == 0) return;
            UpdateInfoPlist(pathToBuiltProject, appIcons.ToArray());
            CreateAppIcons(appIconDirectoryPath, appIcons.ToArray());
            UpdatePbxProject(pathToBuiltProject, appIconDirectoryPath, appIcons.ToArray());
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
                        bundleIconFiles.AddString($"{appIcon.name}_iphone");

                        appDict.SetBoolean("UIPrerenderedIcon", false);
                    }
                }
            }

            {
                var bundleIcons = plist.root.CreateDict("CFBundleIcons~ipad");
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
                        bundleIconFiles.AddString($"{appIcon.name}_ipad");
                        bundleIconFiles.AddString($"{appIcon.name}_ipadpro");

                        appDict.SetBoolean("UIPrerenderedIcon", false);
                    }
                }
            }

            plist.WriteToFile(plistPath);
        }

        private static void CreateAppIcons(string appIconDirectoryPath, AppIcon[] appIcons)
        {
            Directory.CreateDirectory(appIconDirectoryPath);

            foreach (var appIcon in appIcons)
            {
                CreateAppIcon(appIcon.iPhone120Px, 120, $"{appIcon.name}_iphone@2x.png", appIconDirectoryPath);
                CreateAppIcon(appIcon.iPhone180Px, 180, $"{appIcon.name}_iphone@3x.png", appIconDirectoryPath);
                CreateAppIcon(appIcon.iPad152Px, 152, $"{appIcon.name}_ipad@2x.png", appIconDirectoryPath);
                CreateAppIcon(appIcon.iPad167Px, 167, $"{appIcon.name}_ipadpro@2x.png", appIconDirectoryPath);
            }
        }

        private static void CreateAppIcon(Texture2D originalTexture, int size, string fileName, string appIconDirectoryPath)
        {
            var iconTexture = new Texture2D(0, 0);
            iconTexture.LoadImage(File.ReadAllBytes(AssetDatabase.GetAssetPath(originalTexture)));

            var savePath = Path.Combine(appIconDirectoryPath, fileName);
            if (iconTexture.width != size || iconTexture.height != size)
            {
                var renderTexture = new RenderTexture(size, size, 24);
                var tmpRenderTexture = RenderTexture.active;
                RenderTexture.active = renderTexture;
                Graphics.Blit(iconTexture, renderTexture);
                var resizedTexture = new Texture2D(size, size);
                resizedTexture.ReadPixels(new Rect(0,0,size,size),0,0);
                resizedTexture.Apply();
                RenderTexture.active = tmpRenderTexture;
                renderTexture.Release();
                iconTexture = resizedTexture;
            }

            var pngBytes = iconTexture.EncodeToPNG();
            File.WriteAllBytes(savePath, pngBytes);
        }

        private static void UpdatePbxProject(string pathToBuiltProject, string appIconDirectoryPath, AppIcon[] appIcons)
        {
            var pbxProjectPath = Path.Combine(pathToBuiltProject, "Unity-iPhone.xcodeproj", "project.pbxproj");
            var pbxProject = new PBXProject();
            pbxProject.ReadFromFile(pbxProjectPath);

            var targetGuid = pbxProject.GetUnityMainTargetGuid();
            {
                foreach (var appIcon in appIcons)
                {
                    var fileNames = new[] { $"{appIcon.name}_iphone@2x.png", $"{appIcon.name}_iphone@3x.png", $"{appIcon.name}_ipad@2x.png", $"{appIcon.name}_ipadpro@2x.png" };
                    foreach (var fileName in fileNames)
                    {
                        var fileGuid = pbxProject.AddFile(Path.Combine(appIconDirectoryPath, fileName), $"/AppIconChanger/{fileName}", PBXSourceTree.Build);
                        pbxProject.AddFileToBuild(targetGuid, fileGuid);
                    }
                }
            }

            pbxProject.WriteToFile(pbxProjectPath);
        }
    }
}
