namespace Assets.Tiles
{
    using UnityEngine;

    public class SelectedTile : MonoBehaviour
    {
        public string SelectedTagName = "Selected";

        public float YOffset = 0.25f;

        private float y;

        public void Start()
        {
            this.y = this.transform.position.y;
        }

        public void Update()
        {
            float offset = this.CompareTag(this.SelectedTagName) ? this.YOffset : 0;
            var position = this.transform.position;
            this.transform.position = new Vector3(position.x, this.y + offset, position.z);
        }
    }
}
