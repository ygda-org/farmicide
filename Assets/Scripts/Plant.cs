using UnityEngine;
public abstract class Plant : MonoBehaviour{
    
    public abstract float GetHealth();
    public abstract void SetHealth(float health);
    public abstract GridTile GetGridTile();

    public SpriteRenderer GetSprite() { return this.gameObject.GetComponent<SpriteRenderer>(); }
    public GameObject GetGameObject() { return this.gameObject; }

    public abstract void Create(GridTile gridTile_);
    public abstract void Die();
    public abstract void Grow();
    public abstract void Attack();

    public void TakeDamage(float damage) { 
        SetHealth(GetHealth() - damage);
        if (GetHealth() <= 0) Die();
    }
}

// example implementation
public class GreenPlant : Plant {
    
    public float maxHealth;
    private float health;
    private GridTile gridTile;

    public override float GetHealth() { return health; }
    public override void SetHealth(float health_) { health = health_; }
    public override GridTile GetGridTile() { return gridTile; }

    public override void Create(GridTile gridTile_) { 
        gridTile = gridTile_;
        health = maxHealth;
    }
    public override void Die() {}
    public override void Grow() {}
    public override void Attack() {}
}
