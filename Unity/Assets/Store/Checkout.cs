namespace Assets.Store
{
    using UnityEngine;

    public class Checkout : MonoBehaviour
    {
        public GameObject SelectedBuildingPrefab;

        public GameObject VillagePrefab;

        public void StartCheckout(GameObject buildingPrefab)
        {
            this.SelectedBuildingPrefab = buildingPrefab;
        }

        public void FinishCheckout(GameObject purchasedBuilding)
        {
            Debug.Log(purchasedBuilding);
            purchasedBuilding.SendMessage("Purchased");
            this.SelectedBuildingPrefab = null;
        }
    }
}
