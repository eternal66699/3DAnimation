using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    int horizontal, vertical;

    private void Awake()
    {
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        if (PlayerManager.Instance.isSprinting)
        {
            verticalMovement = 2;
        }
        if (PlayerManager.Instance.isWalking)
        {
            verticalMovement = 0.5f;
        }
        PlayerManager.Instance.playerAnim.SetFloat(horizontal, horizontalMovement, 0.1f, Time.deltaTime);
        PlayerManager.Instance.playerAnim.SetFloat(vertical, verticalMovement, 0.1f, Time.deltaTime);
    }
}
