namespace Assets.Tiles
{
    using UnityEngine;

    public class TileSelection : MonoBehaviour
    {
        public GameObject VillagePrefab;

        private GameObject selected;

        private int tileLayer;

        private GameObject building;

        public void Start()
        {
            this.tileLayer = LayerMask.NameToLayer("Tiles");
        }

        public void OnMouseDown()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.layer == this.tileLayer)
            {
                this.selected = hit.collider.gameObject;
                this.selected.tag = "Selected";
            }
        }

        public void OnMouseUp()
        {
            if (this.selected == null)
            {
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool hitSomething = Physics.Raycast(ray, out hit);
            if (!hitSomething || this.selected != hit.collider.gameObject)
            {
                this.selected.SendMessage("Activate");
            }
            else if (this.selected != null)
            {
                this.selected.SendMessage("Deactivate");
            }

            this.selected = null;
        }
    }
}
