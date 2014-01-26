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
                    if ((row == 0)
                        || (col == 0)
                        || (col == this.NumberOfColumns))
                    {
                        continue;
                    }

                    if (col == 0 || col == this.NumberOfColumns || row == 0 || row == this.NumberOfRows)
                    {
                        float angle = 0;
                        if (row == 0)
                        {
                            angle = 0;
                        }
                        else if (col == 0)
                        {
                            angle = 90;
                        }
                        else if (col == this.NumberOfColumns)
                        {
                            angle = 270;
                        }
                        else if (row == this.NumberOfRows)
                        {
                            angle = 180;
                        }

                        this.CreateEvilTile(col, row, angle);
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

        private void CreateEvilTile(int col, int row, float angle)
        {
            var position = new Vector3(col, 0, row);
            var tile = (GameObject)GameObject.Instantiate(
                this.EvilTilePrefab, 
                position, 
                Quaternion.Euler(0, angle, 0));
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

        private void CenterBoard()
        {
            float xOffset = (this.NumberOfColumns / 2f) - 0.5f;
            var position = this.transform.position;
            position.x -= xOffset;
            this.transform.position = position;
        }
    }
}
