using UnityEngine;

public class Jugador : Personaje
{
    [SerializeField] protected float fuerzaSalto;
    Rigidbody2D miRigidBody;
    bool saltar;
    public override void Start()
    {
        base.Start();
        saltar = false;
        miRigidBody = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		 Teclado();
    }
    void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
       
        Girar(movimientoHorizontal);
        Movimiento(movimientoHorizontal);
    }

    void Girar(float movimientoHorizontal)
    {
        if (movimientoHorizontal > 0 && !mirandoDerecha || movimientoHorizontal < 0 && mirandoDerecha)
        {
            CambiarDireccion();
        }
    }

    void Teclado()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            saltar = true;
        }
    }

    void Movimiento(float movimientoHorizontal)
    {
        if (saltar)
        {
            miRigidBody.AddForce(new Vector2(0, fuerzaSalto));
			saltar = false;
        }
		miRigidBody.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento, miRigidBody.velocity.y);
    }
}
