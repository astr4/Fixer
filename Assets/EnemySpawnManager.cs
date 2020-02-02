using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public GameObject Car;
    public GameObject House;
    public GameObject TV;
    public Transform rightSpawnLocation;
    public Transform leftSpawnLocation;
    bool spawned;
    float lastTime;
    float cd;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        cd = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastTime+cd)
        {
            SpawnCar();
            lastTime = Time.time;
            cd = 10f;
        }
    }



    void SpawnCar()
    {
        int rnd = Random.Range(1,3);
        if (rnd == 1)
        {
            GameObject carTemp = Car;



            carTemp.GetComponent<CarController>().rightDirection = true;
            Instantiate(carTemp, new Vector3(leftSpawnLocation.position.x, leftSpawnLocation.position.y, -1), Quaternion.identity);

        }
        
        else if (rnd == 2)
        {
            GameObject carTemp = Car;

            carTemp.GetComponent<CarController>().rightDirection = false;
            Instantiate(carTemp, new Vector3(rightSpawnLocation.position.x, rightSpawnLocation.position.y , -1), Quaternion.identity);

        }
        else if (rnd == 3)
        {
            GameObject houseTemp = House;

            houseTemp.GetComponent<CarController>().rightDirection = false;
            Instantiate(houseTemp, new Vector3(rightSpawnLocation.position.x, rightSpawnLocation.position.y , -1), Quaternion.identity);

        }
        else if (rnd == 4)
        {
            GameObject houseTemp = House;

            houseTemp.GetComponent<CarController>().rightDirection = true;
            Instantiate(houseTemp, new Vector3(leftSpawnLocation.position.x, leftSpawnLocation.position.y, -1), Quaternion.identity);

        }

    }
}
