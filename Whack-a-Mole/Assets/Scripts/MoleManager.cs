using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    [SerializeField]
    private Health curHealth;

    public Cell cell;
    public Mole mole;
    public Heart heart;

    public int mapHeight = 3;
    public int mapWidth = 3;

    public Cell[,] cells;

    private float timer;
    public float spawnTimeLimit = 0.9f;
    Vector3 offset;

    private float difficulty = 0;
    private const int limit = 10000;

    void Start()
    {
        cells = new Cell[mapWidth, mapHeight]; 
        offset = cell.GetComponent<Renderer>().bounds.size;
        CreateCells();
        StartCoroutine(CreateMole());
        StartCoroutine(CreateHeart());
    }


    void Update()
    {
        timer += Time.deltaTime;
        difficulty += timer / limit;

        if(difficulty > spawnTimeLimit)
        {
            difficulty = spawnTimeLimit;
        }
    }


    void CreateCells()
    {
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                Vector3 pos = new Vector3(i * offset.x, -j * offset.y + 1, 0);
                cells[i, j] = Instantiate(cell, pos, Quaternion.identity);
            }
        }
    }

    IEnumerator CreateMole()
    {
        int x, y;
        yield return new WaitForSeconds(Random.Range(1 - difficulty, 2 - difficulty));

        while (curHealth.health > 0)
        {
            x = Random.Range(0, cells.GetLength(0));
            y = Random.Range(0, cells.GetLength(1));

            if (!cells[x, y].GetComponentInChildren<Mole>() && !cells[x, y].GetComponentInChildren<Heart>())
            {
                Mole mMole = Instantiate(mole, cells[x, y].GetComponentInChildren<SpawnPosition>().transform.position, Quaternion.identity);
                mMole.transform.SetParent(cells[x, y].transform);
            }

            yield return new WaitForSeconds(Random.Range(1 - difficulty, 2 - difficulty));
        }
    }

    IEnumerator CreateHeart()
    {
        int x, y;
        yield return new WaitForSeconds(Random.Range(2 + difficulty, 3 + difficulty));

        while (curHealth.health > 0)
        {

            x = Random.Range(0, cells.GetLength(0));
            y = Random.Range(0, cells.GetLength(1));

            if (!cells[x, y].GetComponentInChildren<Mole>() && !cells[x, y].GetComponentInChildren<Heart>())
            {
                Heart mHeart = Instantiate(heart, cells[x, y].GetComponentInChildren<SpawnPosition>().transform.position, Quaternion.identity);
                mHeart.transform.SetParent(cells[x, y].transform);
            }

            yield return new WaitForSeconds(Random.Range(2 + difficulty, 3 + difficulty));
        }
    }
}
