using UnityEditor;
using UnityEngine;

namespace MGrand.ProjectWindow.P01_CornerBadge.Editor
{
    [FilePath("UserSettings/" + nameof(CornerBadgePreferences) + ".asset", FilePathAttribute.Location.ProjectFolder)]
    public class CornerBadgePreferences : ScriptableSingleton<CornerBadgePreferences>
    {
        [field: SerializeField]
        public bool ShowBadges { get; private set; }

        public void ToggleShowBadges()
        {
            ShowBadges = !ShowBadges;
            Save(true);
        }
    }
}
