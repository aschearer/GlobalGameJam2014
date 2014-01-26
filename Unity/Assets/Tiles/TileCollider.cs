namespace Assets.Tiles
{
    using System;

    using UnityEngine;

    public class TileCollider : MonoBehaviour
    {
        public string ActiveTagName = "Active";

        private Transform arrowTransform;

        public void Start()
        {
            this.arrowTransform = this.transform.FindChild("Arrow");
        }

        public void OnTriggerEnter(Collider collider)
        {
            if (this.CompareTag(this.ActiveTagName))
            {
                collider.SendMessage("Rotate", this.arrowTransform.transform.eulerAngles.y - 90);

                Mathf.LerpAngle(
                    collider.gameObject.transform.rotation.eulerAngles.y, 
                    this.arrowTransform.rotation.eulerAngles.y - 90, 
                    0.5f);
            }
        }
    }
}
