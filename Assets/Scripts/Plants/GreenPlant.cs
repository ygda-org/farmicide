using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlant : Plant {
    new public float maxHealth;
    
    public override void Create(GridTile gridTile_) { 
        gridTile = gridTile_;
        health = maxHealth;
    }
    
    public override void Die() {

    }
    public override void Grow() {

    }
    public override void Attack() {

    }
}
