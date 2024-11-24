using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Player_Input playerInput;
    public Plate_Trigger plateTrigger;
    enum Ingredients
    {
        empty,
        veggies,
        bread,
        meat,
        fries,
        cups
    }
    public int heldIngredient;

    //weapon checks
    public bool hasFood;
    public bool hasIngredient;
    public bool hasFries;
    public bool hasSoda;
    public bool hasBurger;
    public bool hasSalad;
    public bool fryCheck;

    //public List<int> ingredients;
    public PlayerObject[] ingredients;
    public GameObject burger;
    public GameObject salad;
    public GameObject fries;
    public GameObject soda;

    private void OnEnable()
    {
        Player_Input.OnInteract += AddIngredient;
    }
    // Start is called before the first frame update
    void Start()
    {
        heldIngredient = 0;
        SetupIngredients();
        playerInput = FindObjectOfType<Player_Input>();
        plateTrigger = GetComponentInChildren<Plate_Trigger>();
        burger.SetActive(false);
        salad.SetActive(false);
        fries.SetActive(false);
        hasFries = false;
        hasSoda = false;
        hasFries = false;
        hasBurger = false;
    }
    private void Update()
    {

    }

    private void SetupIngredients()
    {
        ingredients = GetComponentsInChildren<PlayerObject>();

        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].gameObject.SetActive(i == heldIngredient);
        }
        //old method, ignore

        //string[] ingredientsList = Enum.GetNames(typeof(Ingredients));

        /*        ingredients = new List<int>();
                for(int i = 0; i < ingredientsList.Length; i++)
                {
                    ingredients.Add(i);
                }*/

    }

    private void AddIngredient()
    {
        if (plateTrigger.isTriggered)
        {
            if (!playerInput.holdingWeapon && !hasFood)
            {
                for (int i = 0; i < playerInput.playerObjects.Length; i++)
                {
                    if (playerInput.objectValue == 1)
                    {
                        heldIngredient += 1;
                        ingredients[1].gameObject.SetActive(true);
                        MakeWeapon();
                    }
                    if (playerInput.objectValue == 2)
                    {
                        heldIngredient += 2;
                        ingredients[2].gameObject.SetActive(true);
                        MakeWeapon();
                    }
                    if (playerInput.objectValue == 7)
                    {
                        heldIngredient += 3;
                        ingredients[3].gameObject.SetActive(true);
                        MakeWeapon();
                    }
                    if (playerInput.objectValue == 5)
                    {
                        heldIngredient += 4;
                        ingredients[4].gameObject.SetActive(true);
                        MakeWeapon();
                    }
                    if (playerInput.objectValue == 6)
                    {
                        fryCheck = true;
                        heldIngredient += 5;
                        ingredients[5].gameObject.SetActive(true);
                        MakeWeapon();
                    }
                    playerInput.holdingObject = false;
                    playerInput.CurrentItem(0);
                }
            }
            else if (hasFood)
            {
                if (hasBurger)
                {
                    burger.SetActive(false);
                    playerInput.hasBurger = true;
                    hasBurger = false;
                }
                if (hasSoda)
                {
                    soda.SetActive(false);
                    playerInput.hasSoda = true;
                    hasSoda = false;
                }
                if (hasSalad)
                {
                    salad.SetActive(false);
                    playerInput.hasSalad = true;
                    hasSalad = false;
                }
                if (hasFries)
                {
                    fries.SetActive(false);
                    playerInput.hasFry = true;
                    hasFries = false;
                }
                heldIngredient = 0;
                hasFood = false;
            }
        }
    }

    private void MakeWeapon()
    {
        if (heldIngredient == 5 && !fryCheck)
        {
            foreach (PlayerObject ingredient in ingredients)
            {
                ingredient.gameObject.SetActive(false);
            }
            burger.SetActive(true);
            hasBurger = true;
            hasFood = true;
        }
        if (heldIngredient == 6)
        {
            foreach (PlayerObject ingredient in ingredients)
            {
                ingredient.gameObject.SetActive(false);
            }
            salad.SetActive(true);
            hasSalad = true;
            hasFood = true;
        }
        if (heldIngredient == 5 && fryCheck)
        {
            foreach (PlayerObject ingredient in ingredients)
            {
                ingredient.gameObject.SetActive(false);
            }
            fries.SetActive(true);
            hasFries = true;
            fryCheck = false;
            hasFood = true;
        }
        if (heldIngredient == 3)
        {
            foreach (PlayerObject ingredient in ingredients)
            {
                ingredient.gameObject.SetActive(false);
            }
            soda.SetActive(true);
            hasSoda = true;
            hasFood = true;
        }
    }
}
