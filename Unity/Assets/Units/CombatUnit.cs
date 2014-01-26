namespace Assets.Units
{
    using Assets.Tiles;

    using UnityEngine;

    public class CombatUnit : MonoBehaviour
    {
        private const string StoreTag = "Store";

        private int evilLayer;

        private bool isEvil;

        private int buildingLayer;

        private int killzone;

        public void Start()
        {
            this.evilLayer = LayerMask.NameToLayer("Evil Units");
            this.buildingLayer = LayerMask.NameToLayer("Buildings");
            this.isEvil = this.gameObject.layer == this.evilLayer;
            this.killzone = LayerMask.NameToLayer("Killzone");
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(CombatUnit.StoreTag))
            {
                return;
            }

            if (other.gameObject.layer == this.killzone)
            {
                return;
            }

            if (this.isEvil || other.gameObject.layer == this.evilLayer)
            {
                if (other.gameObject.layer == this.buildingLayer)
                {
                    other.transform.parent.gameObject.tag = SelectedTile.EmptyTagName;
                }

                GameObject.Destroy(other.gameObject);
            }
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collider.collider.gameObject.CompareTag(CombatUnit.StoreTag))
            {
                return;
            }

            if (this.isEvil || collision.collider.gameObject.layer == this.evilLayer)
            {
                if (collision.collider.gameObject.layer == this.buildingLayer)
                {
                    collision.collider.transform.parent.gameObject.tag = SelectedTile.EmptyTagName;
                }

                GameObject.Destroy(collision.collider.gameObject);
            }
        }
    }
}
