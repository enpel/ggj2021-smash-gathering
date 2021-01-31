using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAnimationController : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private CharacterEffectController m_effectController;

    private readonly string IS_IDLE_STR = "isIdle";
    private readonly string IS_RUN_STR = "isRun";
    private readonly string IS_LIFT_STR = "isLift";
    private readonly string IS_THROW_STR = "isThrow";
    private readonly string IS_MINE_STR = "isMine";
    
    public void Idle()
    {
        m_animator.SetBool(IS_IDLE_STR, true);
        m_animator.SetBool(IS_RUN_STR, false);
        m_animator.SetBool(IS_MINE_STR, false);
        m_animator.SetBool(IS_LIFT_STR, false);
        m_animator.SetBool(IS_THROW_STR, false);
        
        m_effectController.ResetEffect();
    }

    public void Run()
    {
        m_animator.SetBool(IS_IDLE_STR, false);
        m_animator.SetBool(IS_RUN_STR, true);
        m_animator.SetBool(IS_MINE_STR, false);
        m_animator.SetBool(IS_LIFT_STR, false);
        m_animator.SetBool(IS_THROW_STR, false);
        
        m_effectController.Smoke();
    }

    public void Mine()
    {
        m_animator.SetBool(IS_MINE_STR, true);
        
        m_effectController.Mine();
    }

    public void Lift()
    {
        m_animator.SetBool(IS_LIFT_STR, true);
    }

    public void Throw()
    {
        m_animator.SetBool(IS_THROW_STR, true);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Idle();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Run();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Mine();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Lift();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Throw();
        }
    }
}
