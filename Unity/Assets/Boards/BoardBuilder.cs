namespace Assets
{
    using UnityEngine;

    public class BoardBuilder : MonoBehaviour
    {
        public int NumberOfColumns = 4;

        public int NumberOfRows = 4;

        public GameObject TilePrefab;

        public void Start()
        {
            for (int col = 0; col < this.NumberOfColumns; col++)
            {
                for (int row = 0; row < this.NumberOfRows; row++)
                {
                    var position = new Vector3(col, 0, row);
                    var tile = (GameObject)GameObject.Instantiate(this.TilePrefab, position, Quaternion.identity);
                    tile.transform.parent = this.transform;
                }
            }

            this.CenterBoard();
        }

        public void Update()
        {
        }

        private void CenterBoard()
        {
            float xOffset = (this.NumberOfColumns / 2f) - 0.5f;
            var position = this.transform.position;
            position.x -= xOffset;
            this.transform.position = position;
        }
    }
}
