using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using HomaGames.HomaBelly;
using UnityEditor;
using UnityEngine;

public static class Build
{
    [MenuItem("Test/tests")]
    public static void Test()
    {
        Debug.Log(typeof(AssetDatabase).GetMethod("ImportPackageImmediately",BindingFlags.Static | BindingFlags.NonPublic));
    }
    
    public static async void Install()
    {
        if (Application.isBatchMode)
        {
            HomaBellyEditorLog.OnLogsAdded += kv =>
            {
                Debug.Log($"[INSTALLER:{kv.Key}] {kv.Value}");
            };
        }
        Debug.Log("Starting installing manifest ...");
        var manifest = await PluginController.RequestPluginManifest("KTmdzEv6");
        await PluginController.InstallPluginManifest(manifest);
        Debug.Log("Ended installing manifest ...");
        EditorApplication.Exit(0);
    }
}