namespace Assets.Boards
{
    using System.Collections.Generic;

    using UnityEngine;

    public class TileObserver : MonoBehaviour
    {
        public int MaxNumberOfActiveTiles = 3;

        public string ActiveTagName = "Active";

        private List<GameObject> activeTiles;

        public void Start()
        {
            if (this.activeTiles == null)
            {
                this.activeTiles = new List<GameObject>();
            }
            else
            {
                while (this.activeTiles.Count > 0)
                {
                    this.activeTiles[0].SendMessage("Deactivate");
                    this.activeTiles.RemoveAt(0);
                }
            }
        }

        public void Update()
        {
            var activeTiles = GameObject.FindGameObjectsWithTag(this.ActiveTagName);
            foreach (var tile in activeTiles)
            {
                if (!this.activeTiles.Contains(tile))
                {
                    this.activeTiles.Add(tile);
                }
            }

            while (this.activeTiles.Count > this.MaxNumberOfActiveTiles)
            {
                this.activeTiles[0].SendMessage("Deactivate");
                this.activeTiles.RemoveAt(0);
            }
        }
    }
}
