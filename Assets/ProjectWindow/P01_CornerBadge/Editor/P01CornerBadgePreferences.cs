using UnityEditor;
using UnityEngine;

namespace MGrand.ProjectWindow.P01_CornerBadge.Editor
{
    [FilePath("UserSettings/" + nameof(P01CornerBadgePreferences) + ".asset", FilePathAttribute.Location.ProjectFolder)]
    public class P01CornerBadgePreferences : ScriptableSingleton<P01CornerBadgePreferences>
    {
        [field: SerializeField]
        public bool ShowBadges { get; private set; }

        [field: SerializeField]
        public Color BadgeColor { get; set; } = Color.green;

        [field: SerializeField]
        public float BadgeSize { get; set; } = 6f;

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
