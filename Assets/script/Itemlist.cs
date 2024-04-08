using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Itemlist 
{

    public Item item;
    public string name;
    public int stacks;

    public Itemlist(Item newitem, string newName, int newstacks)
    {
        item = newitem;
        name = newName;
        stacks = newstacks; 
    }

}
