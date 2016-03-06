﻿using UnityEngine;
using System.Collections;

namespace Completed
{
    using System.Collections.Generic;      
    using UnityEngine.UI;                   

    public class GameManager : MonoBehaviour
    {
        public float levelStartDelay = 2f;            
        public float turnDelay = 0.1f;                          
        public static GameManager instance = null;             
        public bool playersTurn = true;    


        private Text levelText;                                
        private GameObject levelImage;                         
        private BoardManager boardScript;                       
        private List<Enemy> enemies;                           
        private bool enemiesMoving;                             
        private bool doingSetup = true;                         



        
        void Awake()
        {
            
            if (instance == null)

                
                instance = this;

            
            else if (instance != this)

                
                Destroy(gameObject);

            
            DontDestroyOnLoad(gameObject);

            
            enemies = new List<Enemy>();

           
            boardScript = GetComponent<BoardManager>();

            
            InitGame();
        }

        
        void OnLevelWasLoaded(int index)
        {
           
            level++;
            
            InitGame();
        }

        
        void InitGame()
        {
            
            doingSetup = true;

            
            levelImage = GameObject.Find("LevelImage");

         
            
            Invoke("HideLevelImage", levelStartDelay);

           
            enemies.Clear();

            
            boardScript.SetupScene(level);

        }


       

        
        void Update()
        {
            
            if (playersTurn || enemiesMoving || doingSetup)

                
                return;

            
            StartCoroutine(MoveEnemies());
        }

       
        public void AddEnemyToList(Enemy script)
        {
            
            enemies.Add(script);
        }


        
        
        IEnumerator MoveEnemies()
        {
            
            enemiesMoving = true;

           
            yield return new WaitForSeconds(turnDelay);

            
            if (enemies.Count == 0)
            {
                
                yield return new WaitForSeconds(turnDelay);
            }

            
            for (int i = 0; i < enemies.Count; i++)
            {
               
                enemies[i].MoveEnemy();

                
                yield return new WaitForSeconds(enemies[i].moveTime);
            }
            
            playersTurn = true;

            
            enemiesMoving = false;
        }
    }
}