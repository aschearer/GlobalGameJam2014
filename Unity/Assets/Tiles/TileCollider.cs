namespace Assets.Tiles
{
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
                collider.gameObject.transform.rotation = Quaternion.Euler(
                    0,
                    this.arrowTransform.rotation.eulerAngles.y - 90,
                    0);
            }
        }
    }
}
