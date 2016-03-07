using UnityEngine;
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
        private bool enemiesMoving;                             
        private bool doingSetup = true;

        public object enemies { get; private set; }

        void Awake()
        {
            
            if (instance == null)

                
                instance = this;

            
            else if (instance != this)

                
                Destroy(gameObject);

            
            DontDestroyOnLoad(gameObject);

            
            boardScript = GetComponent<BoardManager>();

            
            InitGame();
        }

        
               
        void InitGame()
        {
            
            doingSetup = true;

            
            levelImage = GameObject.Find("LevelImage");

         
            
            Invoke("HideLevelImage", levelStartDelay);

           
           

            
       }


       

        
        void Update()
        {
            
            if (playersTurn || enemiesMoving || doingSetup)

                
                return;

            
            StartCoroutine(MoveEnemies());
        }

       
         
        
        IEnumerator MoveEnemies()
        {
            
            enemiesMoving = true;

           
            yield return new WaitForSeconds(turnDelay);

            
                     
           
            playersTurn = true;

            
            enemiesMoving = false;
        }
    }
}