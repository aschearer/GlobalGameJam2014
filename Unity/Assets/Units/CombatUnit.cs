namespace Assets.Units
{
    using Assets.Tiles;

    using UnityEngine;

    public class CombatUnit : MonoBehaviour
    {
        private int evilLayer;

        private bool isEvil;

        private int buildingLayer;

        public void Start()
        {
            this.evilLayer = LayerMask.NameToLayer("Evil Units");
            this.buildingLayer = LayerMask.NameToLayer("Buildings");
            this.isEvil = this.gameObject.layer == this.evilLayer;
        }

        public void OnTriggerEnter(Collider other)
        {
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
