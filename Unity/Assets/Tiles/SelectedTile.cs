﻿namespace Assets.Tiles
{
    using System;

    using UnityEngine;

    public class SelectedTile : MonoBehaviour
    {
        public string SelectedTagName = "Selected";

        public string ActiveTagName = "Active";

        public float YOffset = 0.25f;

        private float y;

        private GameObject arrow;

        private Vector3 arrowAngle;

        public void Start()
        {
            this.y = this.transform.position.y;
            this.arrow = this.transform.FindChild("Arrow").gameObject;
            this.arrowAngle = this.arrow.transform.rotation.eulerAngles;
        }

        public void Activate()
        {
            this.tag = this.ActiveTagName;
        }

        public void Deactivate()
        {
            this.tag = null;
        }

        public void Update()
        {
            bool isSelected = this.CompareTag(this.SelectedTagName);
            bool isActive = this.CompareTag(this.ActiveTagName);
            float offset = isSelected ? this.YOffset : 0;
            var position = this.transform.position;
            this.transform.position = new Vector3(position.x, this.y + offset, position.z);

            this.arrow.SetActive(isSelected || isActive);
            if (isSelected)
            {
                var delta = Camera.main.WorldToScreenPoint(this.transform.position) - Input.mousePosition;
                var angle = (float)(Math.Atan2(delta.y, delta.x) * Mathf.Rad2Deg);
                var snappedAngle = (float)(Math.Floor((angle + 45) / 90) * 90);

                this.arrow.transform.rotation = Quaternion.Euler(
                    this.arrowAngle.x,
                    this.arrowAngle.y - snappedAngle,
                    this.arrowAngle.z);
            }
        }
    }
}
