namespace Assets.Tiles
{
    using System;

    using UnityEngine;

    public class SelectedTile : MonoBehaviour
    {
        public string SelectedTagName = "Selected";

        public float YOffset = 0.25f;

        private float y;

        private GameObject selector;

        public void Start()
        {
            this.y = this.transform.position.y;
            this.selector = this.transform.FindChild("Selector").gameObject;
        }

        public void Update()
        {
            bool isSelected = this.CompareTag(this.SelectedTagName);
            float offset = isSelected ? this.YOffset : 0;
            var position = this.transform.position;
            this.transform.position = new Vector3(position.x, this.y + offset, position.z);

            this.selector.SetActive(isSelected);
            if (isSelected)
            {
                var delta = Camera.main.WorldToScreenPoint(this.transform.position) - Input.mousePosition;
                var angle = (float)Math.Atan2(delta.y, delta.x);
                this.selector.transform.rotation = Quaternion.Euler(0, -angle * Mathf.Rad2Deg, 0);
            }
        }
    }
}
