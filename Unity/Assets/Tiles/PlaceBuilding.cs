namespace Assets.Tiles
{
    using UnityEngine;

    public class PlaceBuilding : MonoBehaviour
    {
        private GameObject building;

        private Store store;

        public void Start()
        {
            this.store = GameObject.Find("Store").GetComponent<Store>();
        }

        public void OnMouseEnter()
        {
            ////this.building = (GameObject)GameObject.Instantiate(this.VillagePrefab, this.transform.position + this.VillagePrefab.transform.position, Quaternion.identity);
            ////this.building.transform.parent = this.transform;
        }

        public void OnMouseExit()
        {
            if (this.building != null)
            {
                GameObject.Destroy(this.building);
            }
        }
    }
}
