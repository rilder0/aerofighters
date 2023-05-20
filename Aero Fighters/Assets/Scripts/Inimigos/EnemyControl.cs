using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public CaçaEstelar CaçaOriginal;
    public AttackShip AttackOriginal;
    public BattleCruiser CruiserOriginal;

    private float timeAfterCaça;
    private float timeAfterAttackShip;
    private float timeAfterCruiser;

    void Start()
    {
        this.timeAfterCaça = 0;
        this.timeAfterAttackShip = 0;
    }

    void Update()
    {
        CriarCaça();
        CriarAttackShip();
        CriarBattleCruiser();
    }

    private void CriarCaça() {

        this.timeAfterCaça += Time.deltaTime;
        if (this.timeAfterCaça >= 8f)
        {
            this.timeAfterCaça = 0;
            //cada 5 segundo se cria um novo caça estelar

            Vector2 CaçaPositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 CaçaPositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float positionY = Random.Range(4,-3);
            
            Vector2 CaçaPosition = new Vector2(8, positionY);
            
            
            Instantiate(this.CaçaOriginal, CaçaPosition, Quaternion.identity);
        }
    }

    private void CriarAttackShip() {

        this.timeAfterAttackShip += Time.deltaTime;
        if (this.timeAfterAttackShip >= 25f)
        {
            this.timeAfterAttackShip = 0;
            //cada 5 segundo se cria um novo caça estelar

            Vector2 AttackShipPositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 AttackshipPositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float AttackShipPositionY = Random.Range(4,-3);
            
            Vector2 AttackShipPosition = new Vector2(8, AttackShipPositionY);
            
            Instantiate(this.AttackOriginal, AttackShipPosition, Quaternion.identity);
        }
    }

    private void CriarBattleCruiser() {

        this.timeAfterCruiser += Time.deltaTime;
        if (this.timeAfterCruiser >= 10f)
        {
            this.timeAfterCruiser = 0;
            //cada 5 segundo se cria um novo cruzador de batalha

            Vector2 CruiserPositionMaximum = Camera.main.ViewportToScreenPoint(new Vector2(8, 4));
            Vector2 CruiserPositionMinimum = Camera.main.ViewportToScreenPoint(new Vector2(8, -3));

            float CruiserPositionY = Random.Range(4,-3);
            
            Vector2 CruiserPosition = new Vector2(8, CruiserPositionY);
            
            Instantiate(this.CruiserOriginal, CruiserPosition, Quaternion.identity);
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

//pra instanciar mais de um inimigo, primeiramente separei a criação periódia de inimigos em funções: CriarCaça(), e por aí vai. Dentro dessas funções, dei um control c e control v no código base do
//caça estelar e mudei os nomes das variáveis. importante que a variavel que guarda a informação do tempo pra cada inimigo ser criado, não pode ser uma só. Tive que criar o time after pro caça, pra nave
//de ataque e entre outros.



































