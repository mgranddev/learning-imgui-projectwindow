using UnityEditor;
using UnityEngine;

namespace MGrand.ProjectWindow.P01_CornerBadge.Editor
{
    [InitializeOnLoad]
    public static class ProjectWindowBadges
    {
        private const string ShowBadgesMenu = "Tools/Project Window Badges/Show Badges";

        private const float ListViewItemX = 14.0f; // Discovered through testing. Brittle; this may change in the future.
        private const float ListViewIconExtraPaddingX = 3.0f;
        private const float SmallIconSize = 16.0f;

        private const float BadgePadding = 2.0f;

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

            if (Event.current.type == EventType.Repaint)
            {
                DrawBadge(selectionRect);
            }
        }

        private static void DrawBadge(Rect selectionRect)
        {
            var prefs = CornerBadgePreferences.instance;

            var isGridView = selectionRect.height >= selectionRect.width && selectionRect.width > SmallIconSize;
            var isListView = !isGridView && Mathf.Approximately(selectionRect.x, ListViewItemX);

            var iconSize = isGridView
                ? selectionRect.width
                : selectionRect.height;
            var iconRect = new Rect()
            {
                x = selectionRect.x + (isListView ? ListViewIconExtraPaddingX : 0.0f),
                y = selectionRect.y,
                width = iconSize,
                height = iconSize
            };

            var badgeScale = iconSize/SmallIconSize;
            var scaledBadgeSize = badgeScale*prefs.BadgeSize;
            var scaledBadgePadding = badgeScale*BadgePadding;
            var badgeRect = new Rect()
            {
                x = iconRect.xMax - scaledBadgePadding - scaledBadgeSize,
                y = iconRect.yMax - scaledBadgePadding - scaledBadgeSize,
                width = scaledBadgeSize,
                height = scaledBadgeSize
            };

            EditorGUI.DrawRect(badgeRect, prefs.BadgeColor);
        }
    }
}
