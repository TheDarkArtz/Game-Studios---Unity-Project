using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;

[Serializable]
public struct materialCounter2 {
    public string name;
    public TMP_Text textAsset;
}

public class ScrapCraftingTwo : MonoBehaviour
{
    public Transform spawnLocation;
    public materialCounter2[] counters;
    public TMP_Text objectiveText;
    public GameObject[] objectiveIcon;

    private AudioSource audioSource;
    [SerializeField] private AudioClip scrapIntoCrafterSFX;
    [SerializeField] private AudioSource itemCraftingSFX;
    [SerializeField] private AudioClip sculptureOutOfCrafterSFX;

    private int currentObjective;

    [SerializeField] private Dictionary<string, TMP_Text> UiCounters = new Dictionary<string, TMP_Text>();
    [SerializeField] private CraftingRecipe recipes;
    private Dictionary<string,int> whatIsNeeded = new Dictionary<string, int>();
    
    //private Dictionary<string,int> currentCrafting = new Dictionary<string, int>();

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        for(int i = 0; i < counters.Length; i++)
        {
            var x = counters[i];
            UiCounters.Add(x.name,x.textAsset);
        }

        // init Objective
        setObjective();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Scrap"))
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(scrapIntoCrafterSFX);
            itemCraftingSFX.Play();
            whatIsNeeded[other.name] = Math.Max(whatIsNeeded[other.name] - 1, 0);
            newCheckCrafting();
            updateCounter(other.name);
        }
    }   

    // Set the objective the the index of the recipe that is needed
    private void setObjective()
    {
        objectiveIcon[currentObjective].SetActive(false);
        currentObjective = UnityEngine.Random.Range(0,recipes.Results.Count - 1);
        objectiveText.text = recipes.Results[currentObjective].name;
        objectiveIcon[currentObjective].SetActive(true);
        setObjectiveCounters();
    }
    // Update counters values to reflect the recipe needed
    private void setObjectiveCounters()
    {
        print(currentObjective);
        var ItemsNeeded = recipes.Materials[currentObjective];
        for(int i = 0; i < ItemsNeeded.Item.Count; i++)
        {
            if(!whatIsNeeded.TryGetValue(ItemsNeeded.Item[i], out int val))
            {
                whatIsNeeded.Add(ItemsNeeded.Item[i], 0);
            }

            whatIsNeeded[ItemsNeeded.Item[i]] = ItemsNeeded.Amount[i];
            updateCounter(ItemsNeeded.Item[i]);
        }
    }
    // Update UI to reflect the recipe needed
    private void updateCounter(string name)
    {
        if(UiCounters.TryGetValue(name, out TMP_Text value))
        {
            if(whatIsNeeded[name] == 0)
            {
                value.gameObject.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                value.text = whatIsNeeded[name].ToString();
                value.gameObject.transform.parent.gameObject.SetActive(true);
            }
            
        }
    }

    private void newCheckCrafting()
    {
        var pass = true;

        foreach(var x in whatIsNeeded)
        {
            if(x.Value != 0)
            {
                pass = false;
            }
        }

        if(pass == true)
        {
            makeItem(recipes.Results[currentObjective]);
            setObjective();
        }
    }

    private void makeItem(GameObject CraftedItem)
    {
        GameObject spawnedThing = Instantiate(CraftedItem, spawnLocation.position, Quaternion.identity);
        spawnedThing.GetComponent<Rigidbody>().AddForce(spawnLocation.forward * 15, ForceMode.Impulse);
        audioSource.PlayOneShot(sculptureOutOfCrafterSFX);
        itemCraftingSFX.Stop();
    }
}

