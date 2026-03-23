using UnityEngine;

public abstract class PlayerAbility : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    public abstract void UseAbility(Vector2 mP);
}
