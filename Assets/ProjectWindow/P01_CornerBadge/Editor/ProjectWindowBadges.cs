using UnityEditor;

namespace MGrand.ProjectWindow.P01_CornerBadge.Editor
{
    public static class ProjectWindowBadges
    {
        private const string EnableBadgesMenu = "Tools/Project Window Badges/Enable Badges";

        private static bool enabled;

        [MenuItem(EnableBadgesMenu, true)]
        public static bool ValidateEnableBadges()
        {
            Menu.SetChecked(EnableBadgesMenu, enabled);
            return true;
        }

        [MenuItem(EnableBadgesMenu)]
        public static void ToggleEnableBadges()
        {
            enabled = !enabled;
        }
    }
}
