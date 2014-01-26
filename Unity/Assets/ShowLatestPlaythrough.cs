namespace Assets
{
    using Assets.Store;

    using UnityEngine;

    public class ShowLatestPlaythrough : MonoBehaviour
    {
        public void Start()
        {
            var gui = this.GetComponent<GUIText>();
            if (Health.LatestPlayThrough > 0)
            {
                int minutes = (int)(Health.LatestPlayThrough / 60);
                int seconds = (int)(Health.LatestPlayThrough % 60);

                var text = "Last play:";
                if (minutes >= 5)
                {
                    text += " " + minutes + " minutes";
                }

                if (seconds > 0)
                {
                    text += " " + seconds + " seconds";
                }

                gui.text = text;
            }
            else
            {
                gui.text = string.Empty;
            }
        }
    }
}
