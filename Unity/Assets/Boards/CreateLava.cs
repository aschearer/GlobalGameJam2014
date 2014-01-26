namespace Assets.Boards
{
    using Assets.Tiles;

    using UnityEngine;

    public class CreateLava : MonoBehaviour
    {
        public float TimeTillNextLava = 8;

        public GameObject LavaPrefab;

        private float elapsedTime;

        public void Update()
        {
            this.elapsedTime += Time.deltaTime;
            while (this.elapsedTime > this.TimeTillNextLava)
            {
                this.elapsedTime -= this.TimeTillNextLava;
                this.AddLava();
            }
        }

        private void AddLava()
        {
            var emptyTiles = GameObject.FindGameObjectsWithTag(SelectedTile.EmptyTagName);
            int r = Random.Range(0, emptyTiles.Length);
            var tile = emptyTiles[r];

            Debug.Log("Adding lava");
            var position = tile.transform.position;
            position.y += 0.5f;
            var goldMine = (GameObject)GameObject.Instantiate(
                this.LavaPrefab,
                position,
                this.LavaPrefab.transform.rotation);
            goldMine.transform.parent = tile.transform;
            goldMine.transform.localPosition = Vector3.zero;

            tile.tag = SelectedTile.OccupiedTagName;
        }
    }
}
