using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Runtime.InteropServices;

internal static class SymbolicLink
{
#if UNITY_EDITOR_WIN
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, SymLinkFlag dwFlags);

    internal enum SymLinkFlag
    {
        File = 0,
        Directory = 1
    }
#endif
}

public class SymbolicProjectMenu
{

#if UNITY_EDITOR_WIN
    [MenuItem("Edit/Create Symbolic Project")]
    static void CreateSymbolicProject()
    {
        string path = EditorUtility.SaveFolderPanel("Folder", "", "Project");

        string targetAssetPath = Application.dataPath;
        string targetSettingsPath = targetAssetPath.Remove(targetAssetPath.Length - "Assets".Length) + "ProjectSettings";

        string symAssetPath = path + "/Assets";
        string symProjectSettings = path + "/ProjectSettings";

        bool created = SymbolicLink.CreateSymbolicLink(symAssetPath, targetAssetPath, SymbolicLink.SymLinkFlag.Directory);
        created &= SymbolicLink.CreateSymbolicLink(symProjectSettings, targetSettingsPath, SymbolicLink.SymLinkFlag.Directory);

        if (created)
        {
            EditorUtility.DisplayDialog("Success!", "Symbolic 'Assets' and 'Project Settings' folders were created at " + path, "Awesome! Cheers Mark");
        }
        else
        {
            EditorUtility.DisplayDialog("Something Went Wrong!", "Couldn't create the link, you may need to run as Administrator", "OK");
        }
    }
#endif
}