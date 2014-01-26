namespace Assets.Store
{
    using UnityEngine;

    public class Checkout : MonoBehaviour
    {
        public GameObject SelectedBuildingPrefab;

        public GameObject VillagePrefab;

        public void StartCheckout(GameObject buildingPrefab)
        {
            Debug.Log("Starting checkout");
            this.SelectedBuildingPrefab = buildingPrefab;
        }

        public void FinishCheckout(GameObject purchasedBuilding)
        {
            Debug.Log("Finishing checkout");
            purchasedBuilding.SendMessage("Purchased");
            this.SelectedBuildingPrefab = null;
        }
    }
}
