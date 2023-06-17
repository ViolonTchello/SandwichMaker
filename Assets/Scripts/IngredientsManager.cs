using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using System;
using UnityEngine.Playables;

public class IngredientsManager : MonoBehaviour
{
    
    public bool countdownCompleted;

    public GameObject[] ingredientPrefab;
    public GameObject sandwichBasePrefab, sandwichTopPrefab, completeSandwichParent, maxIngredientsText, lessIngredientsText, buttonsBlock;

    public List<GameObject> ingredientObjects; public int ingredientsCount;

    public List<string> ingredientsAdded;

    public bool correctIngredients, correctOrder = true;

    public PlayableDirector deliverAnim;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(sandwichBasePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (!countdownCompleted)
        {
           
        }

    }
    
    public void addIngredient(int i)
    {
        //Instantiate(five, five.transform.position, Quaternion.identity);
        //scriptableSandwich.Spawn(this, i);
        if (ingredientsCount < 3)
        {
            GameObject newIngredient = Instantiate(ingredientPrefab[i]);
            ingredientsCount++;

            ingredientsAdded.Add(ingredientPrefab[i].name);
            ingredientObjects.Add(newIngredient);
        }        
       
        else 
        {
            if (!maxIngredientsText.active)
            {
                lessIngredientsText.SetActive(false);
                maxIngredientsText.SetActive(true); //Shows a warning of max ingredients.
                Invoke("DisableMaxText", 2f); //Wait 2s to disable warning text.
            }
        }
        

    }

    void DisableMaxText()
    {
        maxIngredientsText.SetActive(false); //Disable warning text.
    }

    void DisabLessText()
    {
        lessIngredientsText.SetActive(false); //Disable warning text.
    }

    public void removeIngredient()
    {
        ingredientObjects.RemoveAll(go => go == null); ////Remove null spaces left in list.

        if (ingredientsAdded.Count > 0)
        {

            GameObject lastIngredient = ingredientObjects[ingredientObjects.Count - 1];

 

            ingredientsAdded.RemoveAt(ingredientsAdded.Count - 1); //Remove object from list.
            

            Destroy(lastIngredient); //Destroy object in scene.
            ingredientsCount--; //Reset ingredients count.            

        }

    }

    public void onDeliverClick()
    {

        if (ingredientsCount < 3)
        {
            if (!lessIngredientsText.active)
            {
                maxIngredientsText.SetActive(false);
                lessIngredientsText.SetActive(true); //Shows a warning of max ingredients.
                Invoke("DisabLessText", 2f); //Wait 2s to disable warning text.
            }
        }

        else
        {
            Instantiate(sandwichTopPrefab);


            GameObject[] ingredientObjects = GameObject.FindGameObjectsWithTag("Ingredient");

            foreach (GameObject ingredientObject in ingredientObjects)
            {
                ingredientObject.transform.parent = completeSandwichParent.transform;
            }

            buttonsBlock.SetActive(true);
            deliverAnim.Play();
            Invoke("deliverSandwich", 1.6f);
        }

    }
    public void deliverSandwich()
    {

        correctIngredients = this.GetComponent<Orders>().currentSandwich.ingredients.OrderBy(x => x).SequenceEqual(ingredientsAdded.OrderBy(x => x)); //Compares if the ingredients added are correct.

        correctOrder = this.GetComponent<Orders>().currentSandwich.ingredients.SequenceEqual(ingredientsAdded); //Compare if the ingredients was addded in the correct order.

        
        if (correctIngredients && correctOrder)
        {
            this.GetComponent<Score>().addScore(true);             
        }

        if (correctIngredients && !correctOrder) 
        {
            this.GetComponent<Score>().addScore(false);
        }

        else if(!correctIngredients)
        { 
            this.GetComponent<Score>().removeScore();
        }

        ingredientsAdded.Clear();  //Reset added ingredients List. 
        ingredientsCount = 0; //Reset ingredients Count.
        ingredientObjects.RemoveAll(go => go == null); ////Remove null spaces left in list.


        //Clean ingredients on table.
        GameObject[] ingredientsToClean = GameObject.FindGameObjectsWithTag("Ingredient");        
        foreach (GameObject obj in ingredientsToClean)
        {
           Destroy(obj);
        }

        Invoke("restartTable", .5f);

    }

    public void restartTable()
    {
        Instantiate(sandwichBasePrefab);
        buttonsBlock.SetActive(false);  
        this.GetComponent<Orders>().newOrder(); //Call a new order.
    }
}
