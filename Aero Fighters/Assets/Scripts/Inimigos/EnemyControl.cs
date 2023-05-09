using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public CaçaEstelar CaçaOriginal;
    private float timeAfter;
    void Start()
    {
        this.timeAfter = 0;
    }

    void Update()
    {
        this.timeAfter += Time.deltaTime;
        if (this.timeAfter >= 5f)
        {
            this.timeAfter = 0;
            //cada 5 segundo se cria um novo caça estelar

            Vector2 CaçaPositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 CaçaPositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float positionY = Random.Range(4,-3);
            
            Vector2 CaçaPosition = new Vector2(8, positionY);
            
            
            Instantiate(this.CaçaOriginal, CaçaPosition, Quaternion.identity);
        }
    }
}

//esse codigo serve pra 
//timeAfter é uma variavel que guarda o intervalo de tempo entre a criação de inimigos, ou seja, o tempo descorrido depois da criação de um inimigo a fim de criar outro.
//se esse tempo for = 1s, a cada 1 segundo um inimigo vai ser criado
//this.timeAfter += Time.deltaTime; é basicamente dar a variavel timeAfter a noção de como tempo real está passando, para que ele tenha essas informações e crie inimigos 
//no tempo real. o tempo real é obtido atraves da classe time e o metodo delta time. o incremento na variavel se justifica porque os segundos vao passando e se somando.
//o metodo instantiate é um metodo que cria um novo objeto, e passando como parametro um objeto que já existe, ele vai duplicar

//como eu fiz pro inimigo surgir fora da câmera? eu criei duas posições: CaçaPositionMaximum, que é a posição que eu quero onde o inimigo surga e caçaposition, que é a posição original dele. 
//a ideia é que eu pegue essa nova posição e substitua os valores da posição original com ela, fazendo com que esses novos valores seja sua posição de fato. mas como eu pego essa posição fora
//da câmera? a referência que eu usei foi a câmera, atraves do metodo camera.main.viewporttoscreenpoint. peguei um game object vazio e coloquei ele na posição que eu queria que os inimigos fossem 
//criados, e passei os valores do eixo x e y nesse vector. no caçaposition eu faço isso de novo
//pra que esses inimigos começem a nascer fora da camera, eu preciso passar a posição que eu quero no instantiate, que é o método que tá gerando eles. quaternion.identity garante pra gente que esse
//gameobject nao ta sendo instanciado rotacionado
//como eu fiz pra que o inimigo fosse gerado em diferentes posições do eixo y? eu fiz com que o eixo Y (positionY) tivesse um valor aleatório entre 4 e -3, que são os valores máximo e mínimo, e alterei
//pra que esse valor aleatorio assuma realmente o valor de y: Vector2 CaçaPosition = new Vector2(8, positionY);




































