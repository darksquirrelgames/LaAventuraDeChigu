using UnityEngine;

public class Jugador : Personaje
{
    [SerializeField] protected float fuerzaSalto;
    Rigidbody2D miRigidBody;
    Animator miAnimator;
    [SerializeField] public bool Saltar { get; set; }

    float movimientoHorizontal;
    public override void Start()
    {
        base.Start();
        Saltar = false;
        miRigidBody = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Teclado();
    }
    void FixedUpdate()
    {
        Girar(movimientoHorizontal);
        Movimiento(movimientoHorizontal);
    }

    void Girar(float movimientoHorizontal)
    {
        if (miRigidBody.velocity.y == 0 && (movimientoHorizontal > 0 && !mirandoDerecha || movimientoHorizontal < 0 && mirandoDerecha))
        {
            CambiarDireccion();
        }
    }

    void Teclado()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar = true;
        }
        movimientoHorizontal = Input.GetAxis("Horizontal");
    }

    void Movimiento(float movimientoHorizontal)
    {
        if (Saltar && !miAnimator.GetCurrentAnimatorStateInfo(0).IsName("Saltar") && miRigidBody.velocity.y == 0)
        {
            miAnimator.SetTrigger("Saltar");
            miRigidBody.AddForce(new Vector2(0, fuerzaSalto));
        }
        if (miRigidBody.velocity.y == 0)
        {
            miAnimator.SetFloat("Velocidad",Mathf.Abs(movimientoHorizontal));
            miRigidBody.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento, miRigidBody.velocity.y);
        }

    }
}
