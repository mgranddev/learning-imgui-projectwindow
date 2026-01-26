using UnityEditor;

namespace MGrand.ProjectWindow.P01_CornerBadge.Editor
{
    public static class ProjectWindowBadges
    {
        private const string ShowBadgesMenu = "Tools/Project Window Badges/Show Badges";

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
        }
    }
}
