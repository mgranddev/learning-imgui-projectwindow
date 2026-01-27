using UnityEditor;
using UnityEngine;

namespace MGrand.ProjectWindow.P01_CornerBadge.Editor
{
    [FilePath("UserSettings/" + nameof(CornerBadgePreferences) + ".asset", FilePathAttribute.Location.ProjectFolder)]
    public class CornerBadgePreferences : ScriptableSingleton<CornerBadgePreferences>
    {
        [field: SerializeField]
        public bool ShowBadges { get; private set; }

        [field: SerializeField]
        public int NumEventsReceived { get; private set; }

        public void ToggleShowBadges()
        {
            ShowBadges = !ShowBadges;
            if (ShowBadges)
            {
                NumEventsReceived = 0;
            }
            Save(true);
        }

        public void ReceivedEvent()
        {
            NumEventsReceived++;
        }
    }
}
