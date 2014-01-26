namespace Assets.Boards
{
    using Assets.Store;
    using Assets.Tiles;

    using UnityEngine;

    public class PlaceBuilding : MonoBehaviour
    {
        private GameObject building;

        private Checkout checkout;

        private int tileLayer;

        public void Start()
        {
            this.checkout = GameObject.Find("Store").GetComponent<Checkout>();
            this.tileLayer = LayerMask.NameToLayer("Tiles");
        }

        public void Update()
        {
            if (this.checkout.SelectedBuildingPrefab == null)
            {
                return;
            }

            if (this.building == null)
            {
                Debug.Log("Creating building for placement");
                var position = this.transform.position;
                position.y += 0.5f;
                this.building = (GameObject)GameObject.Instantiate(
                    this.checkout.SelectedBuildingPrefab, 
                    position, 
                    this.checkout.SelectedBuildingPrefab.transform.rotation);
                this.building.transform.parent = this.transform;
                this.building.SetActive(false);
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << this.tileLayer;
            if (Physics.Raycast(ray, out hit, 100, layerMask) && hit.collider.CompareTag(SelectedTile.EmptyTagName))
            {
                this.building.SetActive(true);
                this.building.transform.position = hit.collider.transform.position;
            }
            else
            {
                this.building.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0) && this.building.activeSelf)
            {
                Debug.Log("Placing building");
                this.checkout.SendMessage("FinishCheckout", this.building);
                this.building.transform.parent = hit.collider.transform;
                hit.collider.tag = SelectedTile.OccupiedTagName;
                this.building = null;
            }
        }
    }
}