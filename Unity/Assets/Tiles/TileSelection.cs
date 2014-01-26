namespace Assets.Tiles
{
    using UnityEngine;

    public class TileSelection : MonoBehaviour
    {
        private GameObject selected;

        private int tileLayer;

        public void Start()
        {
            this.tileLayer = LayerMask.NameToLayer("Tiles");
        }

        public void OnMouseDown()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << this.tileLayer;
            if (Physics.Raycast(ray, out hit, 100, layerMask))
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
