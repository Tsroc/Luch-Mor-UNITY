﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * This class is used for interactions between the GrammarContoller and other classes.
 */
public class GeneralMethods : MonoBehaviour
{

    SceneController sc;
    private GameObject player;
    private GameObject wizard;
    private Vector3 homePosition;
    private Vector3 cheesePosition;
    private Vector3 wizardPosition;
    private Vector3 catPosition;
    private string[] directions = { "up", "down", "left", "right" };

    // Start is called before the first frame update
    void Start()
    {
        sc = GameObject.FindObjectOfType<SceneController>();
        player = GameObject.FindGameObjectWithTag("Player");
        wizard = GameObject.FindGameObjectWithTag("Wizard");
        homePosition = GameObject.FindGameObjectWithTag("Home").transform.position;
        cheesePosition = GameObject.FindGameObjectWithTag("PickUp").transform.position;
        wizardPosition = GameObject.FindGameObjectWithTag("Wizard").transform.position;
        catPosition = GameObject.FindGameObjectWithTag("Enemy").transform.position;
    }

    /*
     * Returns the player object
     */
    public GameObject GetPlayer()
    {
        return player;
    }

    /*
     * Gets a Vector3 position of the target.
     */
    private Vector3 GetPosition(string target)
    {
        switch (target)
        {
            case "home":
                return homePosition;
                break;
            case "cheese":
                return cheesePosition;
                break;
            case "wizard":
                return wizardPosition;
                break;
            case "cat":
                return catPosition;
                break;
            default: return new Vector3(0, 0, 0);
        }
    }

    /*
     * Player interactions
     */
    public void PlayerInteractions(string interact)
    {
        switch (interact)
        {
            case "home":
                player.GetComponent<Player>().InteractWithHome();
                break;
            case "cheese":
                player.GetComponent<Player>().InteractWithCheese();
                break;
        }
    }

    /*
     * Wizard interactions, while evolve is not called from the Wizard, it thematically relates to the wizard.
     */
    public void WizardSpells(string spell)
    {
        switch (spell)
        {
            case "sleep":
                wizard.GetComponent<Wizard>().CastSleep();
                break;
            case "evolve":
                player.GetComponent<Player>().Evolve();
                break;
        }
    }

    /*
     * Gets the distance of the destination from the players current location.
     */
    public float GetDistance(string destination)
    {
        switch (destination)
        {
            case "home":
                return Vector3.Distance(player.transform.position, homePosition);
                break;
            case "cheese":
                return Vector3.Distance(player.transform.position, cheesePosition);
                break;
            case "wizard":
                return Vector3.Distance(player.transform.position, wizardPosition);
                break;
            case "cat":
                return Vector3.Distance(player.transform.position, catPosition);
                break;
            default: return 0;
        }
    }

    /*
     * Sets a destination.
     */
    public void SetDestination(string destination)
    {
        if (directions.Contains(destination))
            player.GetComponent<Player>().SetDestination(destination);
        else
            player.GetComponent<Player>().SetDestination(GetPosition(destination));
    }

    public void ClearDestination()
    {
        player.GetComponent<Player>().ClearDestination();
    }

    public bool Gameover()
    {
        return player.GetComponent<Player>().IsGameover();
    }

    public void MenuScene()
    {
        sc.LaunchMainMenu();
    }

    public void QuitGame()
    {
        sc.QuitGame();
    }


}
