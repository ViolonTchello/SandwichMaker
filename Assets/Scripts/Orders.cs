using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Orders : MonoBehaviour
{

    public GameObject ordersPannel;
    public TextMeshProUGUI orderName;
    public RawImage orderIcon;
    public TextMeshProUGUI orderIngredients;

    public Sandwich[] sandwiches; 
    public Sandwich currentSandwich;

    // Start is called before the first frame update
    void Start()
    {
        newOrder();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newOrder()
    {

        //Generates a random order w/o repeating the last one.

        int random = UnityEngine.Random.Range(0, 5);
        int lastNumber = -1;

        if (random == lastNumber)
        {
            random = UnityEngine.Random.Range(0, 5);
        }
        lastNumber = random;

        currentSandwich = sandwiches[random];


        //Fill the Order pannel with the random generated order.
        orderName.text = currentSandwich.name;
        orderIcon.texture = currentSandwich.icon;
        orderIngredients.text =
            "- " + currentSandwich.ingredients[0].ToString() + "\n" +
            "- " + currentSandwich.ingredients[1].ToString() + "\n" +
            "- " + currentSandwich.ingredients[2].ToString();

    }
}
