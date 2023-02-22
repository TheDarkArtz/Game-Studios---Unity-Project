using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrapCrafting : MonoBehaviour
{
    [SerializeField] private CraftingRecipe recipes;
    private Dictionary<string,int> currentCrafting = new Dictionary<string, int>();

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Scrap"))
        {
            if(!currentCrafting.TryGetValue(other.name, out int val))
            {
                print($"make value {other.name}");
                currentCrafting.Add(other.name, 0);
            }

            currentCrafting[other.name] += 1;
            Destroy(other.gameObject);
            checkCrafting();
        }
    }   

    private void checkCrafting()
    {   
        int indexOfItem = 0;
        foreach(ItemAmount x in recipes.Materials)
        {
            var pass = true;
            for(int i = 0; i < x.Item.Count; i++)
            {
                print($"Recipe( Item: {x.Item[i]}, Amount: {x.Amount[i]} )");
                bool isItReal = currentCrafting.TryGetValue(x.Item[i], out int currentlyHave);
                if(isItReal)
                {
                    print($"currently have: {currentlyHave}, Needed: {x.Amount[i]}");
                    if(currentlyHave < x.Amount[i])
                    {
                        pass = false;
                    }
                }
                else
                {
                    pass = false;
                }
            }

            if(pass == true)
            {
                print($"Craft Item, {recipes.Results[indexOfItem].name}");
                currentCrafting[x.Item[indexOfItem]] -= x.Amount[indexOfItem];
                makeItem(recipes.Results[indexOfItem]);
            }

            indexOfItem++;
        }
    }

    private void makeItem(GameObject CraftedItem)
    {
        Instantiate(CraftedItem, transform.position, Quaternion.identity);
    }
}
