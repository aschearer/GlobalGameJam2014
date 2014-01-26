namespace Assets.Buildings
{
    using Assets.Tiles;

    using UnityEngine;

    public class Timeout : MonoBehaviour
    {
        public float TimeToLive = 10;

        private float elapsedTime;

        private int tileLayer;

        public void Start()
        {
            this.tileLayer = LayerMask.NameToLayer("Tiles");
        }

        public void Update()
        {
            this.elapsedTime += Time.deltaTime;
            if (this.elapsedTime >= this.TimeToLive)
            {
                GameObject.Destroy(this.gameObject);
                if (this.gameObject.transform.parent.gameObject.layer == this.tileLayer)
                {
                    this.gameObject.transform.parent.gameObject.tag = SelectedTile.EmptyTagName;
                }
            }
        }
    }
}
