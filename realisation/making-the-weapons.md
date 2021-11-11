# Making the Weapons

Picking up a weapon grants you an attack of a certain type. These attacks are ScriptableObjects that can be slotted into a player. There are two types of attacks, ranged and melee. Each entity has two attack slots. Enemies can have two of either type of attack. The player must have one of each. They can change them on during gameplay.

An attack can have an AttackProperty. These AttackProperties add an additional effect to the attack. The logic for each is defined separately.

![I'll let the class diagram do the talking](<../.gitbook/assets/image (3).png>)

The attacks are set up this way to make it easier to create new attacks for both the player and the enemies. Though if you want to have attacks do something beyond damage, additional logic must be programmed.

In code, for example, the Ranged Attack works like this.

```
public class RangeAttack : Attack
{
    [SerializeField, Range(2, 8)] private int range;
    [SerializeField, Range(1, 3)] private int radius;
    [SerializeField, Range(1, 5)] private int damage;
    [SerializeField] private bool piercing;
    public override void Execute(Transform origin)
    {
        Debug.Log("Performed " + attackName);
        //check all tiles in range if there is a target there
        HashSet<Collider> hits = new HashSet<Collider>();
        Vector3 nextRayOrigin = origin.position;
        for (int i = 0; i < range + 1; i++)
        {
            RaycastHit raycastHit;
            if(Physics.Raycast(new Ray(nextRayOrigin, origin.rotation * Vector3.forward), out raycastHit, 1f))
            {
                Debug.Log(raycastHit.collider.name);
            }
            nextRayOrigin = origin.position + (origin.rotation * Vector3.forward * i);
            property?.ExecuteAttackProperty(nextRayOrigin);
            //if target found, add to targets
            if (raycastHit.collider != null)
            {
                hits.Add(raycastHit.collider);
                //if piercing, keep going
                if (!piercing)
                {
                    break;
                }
            }
        }
        //check radius for targets (manhattan distance)
        if(radius > 1)
        {
            Collider[] colliders = Physics.OverlapSphere(nextRayOrigin, radius);
            foreach(Collider c in colliders)
            {
                if(Mathf.FloorToInt(Vector3.Distance(c.transform.position, nextRayOrigin)) > radius)
                {
                    if(c.transform.position.y == nextRayOrigin.y)
                        hits.Add(c);
                }
            }
        }
        //if target is entity, apply damage
        //if target is interactable, check if it triggers
        foreach (Collider c in hits)
        {
            c.GetComponent<Entity>()?.TakeDamage(damage);
            c.GetComponent<Trigger>()?.Execute(this, origin.position);
        }
    }
}
```

The attacks work by raycasting straight in front of the player, from the center of the screen.&#x20;

Melee Attacks are set up a bit differently. They get a targeting mode, which changes the way targets are determined.

```
public class MeleeAttack : Attack
{
    [SerializeField, Range(1, 5)] private int damage;
    [SerializeField, Range(1, 3)] private int size;
    [SerializeField] private TargetingMode mode;
    public override void Execute(Transform origin)
    {
        Debug.Log("Performed " + attackName);

        HashSet<Collider> hits = new HashSet<Collider>();
        Vector3 nextRayOrigin = origin.position;
        switch (mode)
        {
            case TargetingMode.Front:
                for (int i = 0; i < size; i++)
                {
                    RaycastHit raycastHit;
                    Physics.Raycast(new Ray(nextRayOrigin, origin.rotation * Vector3.forward), out raycastHit, 1f);
                    nextRayOrigin = origin.position + (origin.rotation * Vector3.forward * i);
                    //if target found, add to targets
                    if (raycastHit.collider != null)
                    {
                        hits.Add(raycastHit.collider);
                    }
                }
                break;
            case TargetingMode.Wide:
                //TODO: draw perpendicular line in front of you of a given size
                break;
            case TargetingMode.Area:
                Collider[] colliders = Physics.OverlapSphere(nextRayOrigin, size);
                foreach (Collider c in colliders)
                {
                    if (Mathf.RoundToInt(Vector3.Distance(c.transform.position, nextRayOrigin)) > size)
                    {
                        if (c.transform.position.y == nextRayOrigin.y && c.transform.position != origin.position)
                            hits.Add(c);
                    }
                }
                break;
        }
        foreach (Collider c in hits)
        {
            property?.ExecuteAttackProperty(origin.position);
            c.GetComponent<Trigger>()?.Execute(this, origin.position);
            c.GetComponent<Entity>()?.TakeDamage(damage);
        }
    }
}
```

An attack property is what adds the special effects to an attack. This IceBeamProperty is what makes the Ice Beam the Ice Beam, instead of just another ranged attack.

```
public class IceBeamProperty : AttackProperty
{
    [SerializeField] Transform iceTilePrefab;
    public override void ExecuteAttackProperty(Vector3 location)
    {
        Debug.Log("Executing Beam Effect");
        Tile currentTile = GridController.Instance.GetTileFromWorldPosition(location);
        Debug.Log("Checking " + currentTile?.ToString());
        if (currentTile?.GetFlooded() == false)
        {
            Debug.Log(currentTile.ToString() + " is not flooded");
            if (currentTile?.Floor == false)
            {
                Debug.Log(currentTile.ToString() + " has no floor");
                Tile iceTile = GridController.Instance.GetTileFromWorldPosition(location + Vector3.down);
                if (iceTile?.Ceiling == false)
                {
                    Debug.Log(iceTile.ToString() + " has no ceiling");
                    if (iceTile?.GetFlooded() == true)
                    {
                        Debug.Log(iceTile.ToString() + " is flooded");
                        Debug.Log("Spawning ice on top of " + iceTile.ToString());
                        Instantiate(iceTilePrefab, location, Quaternion.identity);
                        GridController.Instance.UpdatePassability(location);
                        GridController.Instance.UpdatePassability(location + Vector3.down);
                    }
                }
            }
        }
    }
}
```
