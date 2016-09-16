using UnityEngine;
using System.Collections;

public class SpawnBomb : MonoBehaviour {

    [SerializeField]private GameObject bullet;
    private GameObject[] locations;
    private float reloadTimer = 1;
    private float timer;
    private int randomPlayer;

	void Start () {
        locations = GameObject.FindGameObjectsWithTag("Player");
        CreateBomb();
        MoveBomb();
    }

    void Update()
    {
        if(timer >= reloadTimer)
        {
            CreateBomb();
            timer = 0;
            randomPlayer = Random.Range(0, 2);
            MoveBomb();
        }
        timer += Time.deltaTime;
    }

    void CreateBomb()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }

    void MoveBomb()
    {
        float newPos = locations[randomPlayer].transform.position.x;
        transform.position = new Vector3(newPos, transform.position.y, transform.position.z);
    }
}
