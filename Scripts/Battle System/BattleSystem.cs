
using CardGameUIEffect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//The current state of the battle
namespace BattleSystem
{
    public enum BattleState{ PLAYERTURN,ENEMYTURN,WON,LOST}


    public class BattleSystem : MonoBehaviour
    {
        #region Parameters
        private BattleState battleState = BattleState.PLAYERTURN;

        //TODO: Recieve characters from event system.
        [SerializeField]
        private List<GameObject> characters;
        private List<Unit> characterUnits;
        [Tooltip("The number of Character Stations must equal number of Characters")]
        [SerializeField]
        private List<Transform> characterStations;

        [SerializeField]
        private List<GameObject> enemies;
        private List<Unit> enemyUnits;
        [Tooltip("The number of enemy Stations must equal number of enemies")]
        [SerializeField]
        private List<Transform> enemyStations;

        [Tooltip("UI for ending your turn.")]
        [SerializeField]
        private Button endTurnButton;

        #endregion

        #region LifeCycle Methods
        // Start is called before the first frame update
        void Start()
        {
            this.SetupBattle();
            endTurnButton.onClick.AddListener(delegate { EndTurn(); });
        }
        #endregion

        #region Public Methods

        private void FixedUpdate()
        {
            
        }
        
        private void EndTurn()
        {
            switch (battleState)
            {
                case BattleState.ENEMYTURN:
                    battleState = BattleState.PLAYERTURN;
                    EventManager.current.EndTurnTrigger(true);
                    endTurnButton.gameObject.SetActive(true);
                    return;
                case BattleState.PLAYERTURN:
                    battleState = BattleState.ENEMYTURN;
                    EventManager.current.EndTurnTrigger(false);
                    endTurnButton.gameObject.SetActive(false);
                    return;
                case BattleState.WON:
                    //TODO Implement winning battle functionality
                    return;
                case BattleState.LOST:
                    //TODO Implement losing battle functionality
                    return;
            }
        }

        void SetupBattle()
        {
            int count = 0;
            int id = 0;
            if (characters.Count != characterStations.Count | enemies.Count != enemyStations.Count)
            {
                Debug.Log("Characters/Enemies length and Character/Enemies_Stations length index not aligned");
                return;
            }
            foreach (GameObject character in characters)
            {
                Instantiate(character, characterStations[count].transform);
                character.GetComponent<Unit>().setId(id);
                count++;
                id++;
            }
            count = 0;
            foreach (GameObject enemy in enemies)
            {

                GameObject temp = Instantiate(enemy, enemyStations[count].transform);
                enemy.GetComponent<Unit>().setId(id);
                id++;
                count++;
            }
        }
        #endregion

        
    }
}
