namespace Assets
{
    using UnityEngine;

    public class BoardBuilder : MonoBehaviour
    {
        public int NumberOfColumns = 4;

        public int NumberOfRows = 4;

        public GameObject TilePrefab;

        public GameObject EvilTilePrefab;

        public Material WhiteMaterial;

        public Material BlackMaterial;

        public void Start()
        {
            int i = 0;
            for (int col = 0; col < this.NumberOfColumns + 1; col++)
            {
                bool shouldIncrement = false;
                for (int row = 0; row < this.NumberOfRows + 1; row++)
                {
                    if ((col == 0 && row == 0)
                        || (col == 0 && row == this.NumberOfRows)
                        || (col == this.NumberOfColumns && row == 0)
                        || (col == this.NumberOfColumns && row == this.NumberOfRows))
                    {
                        continue;
                    }

                    if (col == 0 || col == this.NumberOfColumns || row == 0 || row == this.NumberOfRows)
                    {
                        this.CreateEvilTile(col, row);
                    }
                    else
                    {
                        this.CreateTile(col, row, i);
                        i++;
                        shouldIncrement = true;
                    }
                }

                if (shouldIncrement)
                {
                    i += 2;
                }
            }

            this.CenterBoard();
        }

        private void CreateEvilTile(int col, int row)
        {
            var position = new Vector3(col, 0, row);
            var tile = (GameObject)GameObject.Instantiate(this.EvilTilePrefab, position, this.EvilTilePrefab.transform.rotation);
            tile.transform.parent = this.transform;
        }

        private void CreateTile(int col, int row, int i)
        {
            var position = new Vector3(col, 0, row);
            var tile = (GameObject)GameObject.Instantiate(this.TilePrefab, position, this.TilePrefab.transform.rotation);
            tile.transform.parent = this.transform;
            bool isWhite = i % 2 == 0;
            tile.renderer.material = isWhite ? this.WhiteMaterial : this.BlackMaterial;
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
