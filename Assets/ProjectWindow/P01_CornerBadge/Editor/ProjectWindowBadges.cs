using UnityEditor;
using UnityEngine;

namespace MGrand.ProjectWindow.P01_CornerBadge.Editor
{
    [InitializeOnLoad]
    public static class ProjectWindowBadges
    {
        private const string ShowBadgesMenu = "Tools/Project Window Badges/Show Badges";

        static ProjectWindowBadges()
        {
            if (CornerBadgePreferences.instance.ShowBadges)
            {
                EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
            }
        }

        [MenuItem(ShowBadgesMenu, true)]
        public static bool ValidateShowBadges()
        {
            Menu.SetChecked(ShowBadgesMenu, CornerBadgePreferences.instance.ShowBadges);
            return true;
        }

        [MenuItem(ShowBadgesMenu)]
        public static void ToggleShowBadges()
        {
            CornerBadgePreferences.instance.ToggleShowBadges();
            if (CornerBadgePreferences.instance.ShowBadges)
            {
                EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
            }
            else
            {
                EditorApplication.projectWindowItemOnGUI -= OnProjectWindowItemGUI;
                PrintEventCount();
            }
        }

        [MenuItem("Tools/Project Window Badges/Print Event Count")]
        public static void PrintEventCount()
        {
            Debug.Log($"Number of events received: {CornerBadgePreferences.instance.NumEventsReceived}");
        }

        private static void OnProjectWindowItemGUI(string guid, Rect selectionRect)
        {
            CornerBadgePreferences.instance.ReceivedEvent();
        }
    }
}
