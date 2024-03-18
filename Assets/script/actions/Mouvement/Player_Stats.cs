using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "PlayerStats/New PlayerStats Container")]
public class Player_Stats : ScriptableObject
{
    public float mouvement_speed = 40f;
    public float horizontalMove = 0f;
    float vitesseInit;
    [SerializeField] float jump_speed = 10f;
    [SerializeField] float dash_speed = 2f;
    [SerializeField] float dash_duration = 0.1f;
    [SerializeField] float couldown = 3f;
    [SerializeField] Animator Animator_player;
    [SerializeField] SpriteRenderer sprite_renderer;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] bool dashUp = true;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool CanMove = true;
    public bool PlayerControl = true;
    [SerializeField] int nbSaut = 1;
    [SerializeField] float groundCheckRadius;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask CollisionsLayers;
    private Vector3 m_Velocity = Vector3.zero;
    private bool m_FacingRight = true;
    [Range(0, .3f)][SerializeField] private float MovementSmoothing = .05f;





}
