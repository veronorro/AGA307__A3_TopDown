using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : GameBehaviour
{
    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TMP_Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {

        //Allows us to get information about units from Unit script. Instantiate spawns prefabs in.
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        //dialogue text that shows up in player box. Change this to another pop up later...?
        dialogueText.text = enemyUnit.unitName + " heckles you...";

        playerHUD.SetHUD(playerUnit);
        playerHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //Damage enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        

        yield return new WaitForSeconds(0.5f);

        //check enemy hp/is dead
        if(isDead)
        {
            //end battle
            state = BattleState.WON;
            EndBattle();

        }
        else
        {
            //enemy turn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " is screaming at you...";
        yield return new WaitForSeconds(3f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You've satisfied the angry customer!";
            new WaitForSeconds(5f);
            _UIT.FromCombatScene();
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "They were right, maybe you don't know what you're talking about...";
            new WaitForSeconds(5f);
            _UIT.FromCombatScene();
        }
          
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose what to do...";

    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }

    public void OnFleeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        _UIT.FromCombatScene();
    }

}
