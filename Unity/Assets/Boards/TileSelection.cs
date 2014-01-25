namespace Assets.Boards
{
    using UnityEngine;

    public class TileSelection : MonoBehaviour
    {
        private GameObject selected;

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    this.selected = hit.collider.gameObject;
                    this.selected.tag = "Selected";
                }
            }
            else if (Input.GetMouseButtonUp(0) && this.selected != null)
            {
                this.selected.tag = null;
                this.selected = null;
            }
        }
    }
}
