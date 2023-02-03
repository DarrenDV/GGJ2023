using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class EnemyMovement : MonoBehaviour
{
    CharacterMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.SetDirection(FollowPlayer());
    }

    Vector2 FollowPlayer()
    {
        Vector2 directionToPlayer = new Vector2();
        directionToPlayer = (this.transform.position - GameManager.Instance.player.transform.position).normalized;
        return -directionToPlayer;
    }
}
