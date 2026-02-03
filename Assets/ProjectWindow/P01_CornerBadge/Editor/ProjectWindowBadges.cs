using UnityEditor;
using UnityEngine;

namespace MGrand.ProjectWindow.P01_CornerBadge.Editor
{
    [InitializeOnLoad]
    public static class ProjectWindowBadges
    {
        private const string MenuRoot = "Tools/P01: Corner Badge";
        private const string ShowBadgesMenu = MenuRoot + "/Show Badges";

        private const float ListViewItemX = 14.0f; // Discovered through testing. Brittle; this may change in the future.
        private const float ListViewIconExtraPaddingX = 3.0f;
        private const float SmallIconSize = 16.0f;

        private const float BadgePadding = 2.0f;

        static ProjectWindowBadges()
        {
            if (P01CornerBadgeUserSettings.instance.ShowBadges)
            {
                EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
            }
        }

        [MenuItem(ShowBadgesMenu, true)]
        public static bool ValidateShowBadges()
        {
            Menu.SetChecked(ShowBadgesMenu, P01CornerBadgeUserSettings.instance.ShowBadges);
            return true;
        }

        [MenuItem(ShowBadgesMenu)]
        public static void ToggleShowBadges()
        {
            P01CornerBadgeUserSettings.instance.ToggleShowBadges();
            if (P01CornerBadgeUserSettings.instance.ShowBadges)
            {
                EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
            }
            else
            {
                EditorApplication.projectWindowItemOnGUI -= OnProjectWindowItemGUI;
                PrintEventCount();
            }
        }

        [MenuItem(MenuRoot + "/Print Event Count")]
        public static void PrintEventCount()
        {
            Debug.Log($"Number of events received: {P01CornerBadgeUserSettings.instance.NumEventsReceived}");
        }

        private static void OnProjectWindowItemGUI(string guid, Rect selectionRect)
        {
            P01CornerBadgeUserSettings.instance.ReceivedEvent();

            if (Event.current.type == EventType.Repaint)
            {
                DrawBadge(selectionRect);
            }
        }

        private static void DrawBadge(Rect selectionRect)
        {
            var settings = P01CornerBadgeUserSettings.instance;

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
            var scaledBadgeSize = badgeScale*settings.BadgeSize;
            var scaledBadgePadding = badgeScale*BadgePadding;
            var badgeRect = new Rect()
            {
                x = iconRect.xMax - scaledBadgePadding - scaledBadgeSize,
                y = iconRect.yMax - scaledBadgePadding - scaledBadgeSize,
                width = scaledBadgeSize,
                height = scaledBadgeSize
            };

            EditorGUI.DrawRect(badgeRect, settings.BadgeColor);
        }
    }
}
