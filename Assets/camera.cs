using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    private float targetposex;
    private float targetposey;

    private float posx;
    private float posy;

    public float derechamax;
    public float izquierdamax;

    public float alturamax;
    public float alturamin;

    public float speed;
    public bool encendido = true;

    private void Awake()
    {
        posx = targetposex + derechamax;
        posy = targetposey + alturamax;
        transform.position = Vector3.Lerp(transform.position, new Vector3(posx, posy, -1), 1);
    }

    void Start()
    {

    }
    void MOve_Cam()
    {
        if (encendido)
        {
            if (target)
            {
                targetposex = target.transform.position.x;
                targetposey = target.transform.position.y;
                if (targetposex > derechamax && targetposex < izquierdamax)
                {
                    posx = targetposex;
                }
                if (targetposey < alturamax && targetposey > alturamin)
                {
                    posy = targetposey;
                }
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(posx, posy, -1), speed * Time.deltaTime);
        }
    }

    void LateUpdate()
    {

    }
    private void Update()
    {
        MOve_Cam();
    }
}
