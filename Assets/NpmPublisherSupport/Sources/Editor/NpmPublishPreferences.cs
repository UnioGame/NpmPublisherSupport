using System;
using UnityEditor;

namespace NpmPublisherSupport
{
    public static class NpmPublishPreferences
    {
        public const string RegistryPrefKey = "codewriter.npm-publisher-support.registry";
        public const string AllRegistriesPrefKey = "codewriter.npm-publisher-support.all-registries";
        public const string UpdateVersionRecursivelyPrefKey = "codewriter.npm-publisher-support.update-recursively";
        public const string NodeJsLocationKey = "codewriter.npm-publisher-support.node_js_location";
        public const string OverrideNodeJsLocationKey = "codewriter.npm-publisher-support.override_node_js_location";

        public static string NpmPackageLoader => "com.codewriter.npm-package-loader";

        public static string Registry
        {
            get => EditorPrefs.GetString(RegistryPrefKey, string.Empty);
            set
            {
                EditorPrefs.SetString(RegistryPrefKey, value);

                if (Array.IndexOf(AllRegistries, value) == -1)
                {
                    var registries = AllRegistries;
                    ArrayUtility.Add(ref registries, value);
                    AllRegistries = registries;
                }
            }
        }

        public static string NodeJsLocation
        {
            get => EditorPrefs.GetString(NodeJsLocationKey,string.Empty);
            set => EditorPrefs.SetString(NodeJsLocationKey,value);
        } 
        
        public static bool OverrideNodeJsLocation
        {
            get => EditorPrefs.GetBool(OverrideNodeJsLocationKey,false);
            set => EditorPrefs.GetBool(OverrideNodeJsLocationKey,value);
        } 

        public static string[] AllRegistries
        {
            get => EditorPrefs.GetString(AllRegistriesPrefKey, "").Split('|');
            set => EditorPrefs.SetString(AllRegistriesPrefKey, string.Join("|", value));
        }

        public static string[] EscapedAllRegistries => EditorPrefs.GetString(AllRegistriesPrefKey, "")
            .Replace('/', '\u2215')
            .Split('|');

        internal static bool UpdateVersionRecursively
        {
            get => EditorPrefs.GetInt(UpdateVersionRecursivelyPrefKey, 1) == 1;
            set => EditorPrefs.SetInt(UpdateVersionRecursivelyPrefKey, value ? 1 : 0);
        }
    }
}