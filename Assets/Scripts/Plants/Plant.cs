using UnityEngine;
public abstract class Plant : MonoBehaviour{
    // Fields
    public float maxHealth {get;}
    public float health {get; set;}
    public GridTile gridTile {get; set;}


    public abstract void Create(GridTile gridTile_);
    public abstract void Die();
    public abstract void Grow();
    public abstract void Attack();

    public void TakeDamage(float damage) { 
        health -= damage;
        if (health <= 0) Die();
    }
}

// example implementation
// public class GreenPlant : Plant {

//     public override void Create(GridTile gridTile_) { 
//         gridTile = gridTile_;
//         health = maxHealth;
//     }
    
//     public override void Die() {}
//     public override void Grow() {}
//     public override void Attack() {}
// }
