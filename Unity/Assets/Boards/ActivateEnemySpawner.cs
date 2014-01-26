namespace Assets.Boards
{
    using UnityEngine;

    public class ActivateEnemySpawner : MonoBehaviour
    {
        public GameObject UnitPrefab;

        public int NumberOfEnemiesToSpawn = 1;

        public int EnemyIncreasePerWave = 2;

        public float SecondsTillSpawn = 10f;

        public float SecondsTillSpawnDecreasePerWave = 0.1f;

        public float MinSecondsTillSpawn = 1f;

        private int wave = 0;

        private float spawnTimer;

        private float createUnitTimer;

        private int enemiesToSpawn;

        public void Update()
        {
            this.spawnTimer -= Time.deltaTime;
            if (this.spawnTimer <= 0)
            {
                this.spawnTimer = this.CalculateTimeTillNextSpawn();
                var tile = this.GetEvilTile();
                tile.SendMessage("SpawnUnits", this.NumberOfEnemiesToSpawn + (this.wave * this.EnemyIncreasePerWave));
                this.wave++;
            }
        }

        private float CalculateTimeTillNextSpawn()
        {
            return Mathf.Max(this.SecondsTillSpawn - this.wave * this.SecondsTillSpawnDecreasePerWave, MinSecondsTillSpawn);
        }

        private GameObject GetEvilTile()
        {
            var evilTiles = GameObject.FindGameObjectsWithTag("Evil Tile");
            int i = Random.Range(0, evilTiles.Length);
            return evilTiles[i];
        }
    }
}