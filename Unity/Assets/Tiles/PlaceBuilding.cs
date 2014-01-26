namespace Assets.Tiles
{
    using Assets.Store;

    using UnityEngine;

    public class PlaceBuilding : MonoBehaviour
    {
        private GameObject building;

        private Checkout checkout;

        private bool checkoutCompleted;

        public void Start()
        {
            this.checkout = GameObject.Find("Store").GetComponent<Checkout>();
        }

        public void OnMouseEnter()
        {
            if (this.checkout.SelectedBuildingPrefab != null)
            {
                this.checkoutCompleted = false;
                var position = this.transform.position;
                position.y += 0.5f;
                this.building = (GameObject)GameObject.Instantiate(
                    this.checkout.SelectedBuildingPrefab, 
                    position, 
                    Quaternion.identity);
                this.building.transform.parent = this.transform;
            }
        }

        public void OnMouseExit()
        {
            if (this.building != null && !this.checkoutCompleted)
            {
                GameObject.Destroy(this.building);
            }

            this.building = null;
            this.checkoutCompleted = false;
        }

        public void OnMouseDown()
        {
            if (this.building != null && !this.checkoutCompleted)
            {
                this.checkout.SendMessage("FinishCheckout", this.building);
                this.building = null;
                this.checkoutCompleted = true;
            }
        }
    }
}
