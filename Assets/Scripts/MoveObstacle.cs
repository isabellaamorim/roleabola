using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float velocidade = 2f; 
    public float amplitude = 3f;  
    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position; 
    }

    void Update()
    {
        float movimento = Mathf.PingPong(Time.time * velocidade, amplitude) - (amplitude / 2);
        transform.position = new Vector3(posicaoInicial.x + movimento, posicaoInicial.y, posicaoInicial.z);
    }
}
