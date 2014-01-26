namespace Assets.Store
{
    using Assets.Buildings;

    using UnityEngine;

    public class Checkout : MonoBehaviour
    {
        public GameObject SelectedBuildingPrefab;

        private Bank bank;

        public void Start()
        {
            this.bank = GameObject.Find("Bank").GetComponent<Bank>();
        }

        public void StartCheckout(GameObject buildingPrefab)
        {
            Debug.Log("Starting checkout");
            this.SelectedBuildingPrefab = buildingPrefab;
        }

        public void FinishCheckout(GameObject purchasedBuilding)
        {
            Debug.Log("Finishing checkout");
            purchasedBuilding.SendMessage("Purchased");
            this.bank.SendMessage("Deduct", purchasedBuilding.GetComponent<Buyable>().Price);
            this.SelectedBuildingPrefab = null;
        }
    }
}
