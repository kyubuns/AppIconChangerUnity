using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

public static class Build
{
    public static void Test()
    {
        var buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = new[] { "Assets/Demo/SampleScene.unity" },
            locationPathName = "Build",
            target = BuildTarget.iOS,
            options = BuildOptions.None
        };

        var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        var summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}