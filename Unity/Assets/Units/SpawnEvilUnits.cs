namespace Assets.Units
{
    using UnityEngine;

    public class SpawnEvilUnits : MonoBehaviour
    {
        public GameObject UnitPrefab;

        public int NumberOfEnemiesToSpawn = 20;

        public float SpawnDuration = 1;

        public float SecondsTillSpawn = 5;

        private float spawnTimer;

        private float createUnitTimer;

        private int enemiesToSpawn;

        private GameObject spawnTile;

        public void Update()
        {
            this.spawnTimer += Time.deltaTime;
            if (this.spawnTimer >= this.SecondsTillSpawn)
            {
                this.spawnTimer -= this.SecondsTillSpawn;
                this.enemiesToSpawn += this.NumberOfEnemiesToSpawn;
                this.spawnTile = this.GetEvilTile();
            }

            if (this.enemiesToSpawn > 0)
            {
                this.createUnitTimer += Time.deltaTime;
                var timeBetweenUnitSpawns = this.SpawnDuration / this.NumberOfEnemiesToSpawn;
                if (this.createUnitTimer >= timeBetweenUnitSpawns && this.enemiesToSpawn > 0)
                {
                    this.createUnitTimer -= timeBetweenUnitSpawns;
                    this.enemiesToSpawn--;
                    var position = this.spawnTile.transform.position;
                    var unit = (GameObject)GameObject.Instantiate(this.UnitPrefab, position, Quaternion.identity);
                    unit.transform.parent = this.transform;
                }
            }
        }

        private GameObject GetEvilTile()
        {
            var evilTiles = GameObject.FindGameObjectsWithTag("Evil Tile");
            int i = Random.Range(0, evilTiles.Length);
            return evilTiles[i];
        }
    }
}