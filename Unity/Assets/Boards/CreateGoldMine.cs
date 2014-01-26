namespace Assets.Boards
{
    using Assets.Tiles;

    using UnityEngine;

    public class CreateGoldMine : MonoBehaviour
    {
        public float TimeTillNextGoldMine = 4;

        public GameObject GoldMinePrefab;

        private float elapsedTime;

        public void Update()
        {
            this.elapsedTime += Time.deltaTime;
            while (this.elapsedTime > this.TimeTillNextGoldMine)
            {
                this.elapsedTime -= this.TimeTillNextGoldMine;
                this.AddGoldMine();
            }
        }

        private void AddGoldMine()
        {
            var emptyTiles = GameObject.FindGameObjectsWithTag(SelectedTile.EmptyTagName);
            int r = Random.Range(0, emptyTiles.Length);
            var tile = emptyTiles[r];

            Debug.Log("Adding goldmine");
            var position = tile.transform.position;
            position.y += 0.5f;
            var goldMine = (GameObject)GameObject.Instantiate(
                this.GoldMinePrefab,
                position,
                this.GoldMinePrefab.transform.rotation);
            goldMine.transform.parent = tile.transform;
            goldMine.transform.localPosition = Vector3.zero;

            tile.tag = SelectedTile.OccupiedTagName;
        }
    }
}
