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

        private Vector3 selectorAngle;

        public void Start()
        {
            this.y = this.transform.position.y;
            this.selector = this.transform.FindChild("Selector").gameObject;
            this.selectorAngle = this.selector.transform.rotation.eulerAngles;
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
                var angle = (float)(Math.Atan2(delta.y, delta.x) * Mathf.Rad2Deg);

                this.selector.transform.rotation = Quaternion.Euler(
                    this.selectorAngle.x,
                    this.selectorAngle.y - angle,
                    this.selectorAngle.z);
            }
        }
    }
}
