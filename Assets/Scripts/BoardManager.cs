using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System;

public class BoardManager : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int minimum;             
        public int maximum;             


        //constructor.
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }


    public int columns = 20;
    public int rows = 10;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();


    void InitialiseList()
    {
       
        gridPositions.Clear();

        
        for (int x = 1; x < columns - 1; x++)
        {
         
            for (int y = 1; y < rows - 1; y++)
            {
                
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    Vector3 RandomPosition()
    {
        
        int randomIndex = Random.Range(0, gridPositions.Count);

        
        Vector3 randomPosition = gridPositions[randomIndex];

       
        gridPositions.RemoveAt(randomIndex);

       
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        
        int objectCount = Random.Range(minimum, maximum + 1);

       
        for (int i = 0; i < objectCount; i++)
        {
            
            Vector3 randomPosition = RandomPosition();

           
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }



    public void SetupScene(int level)
    {

        int enemyCount = (int)Mathf.Log(level, 2f);

    }


}
