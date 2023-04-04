//        _______ ______ _   _  _____   //\   ____  
//     /\|__   __|  ____| \ | |/ ____| |/_\| / __ \     LEIA SEGUINDO OS MARCADORES 1,2,3,4 PARA FACILITAR O ENTENDIMENTO
//    /  \  | |  | |__  |  \| | |       / \ | |  | |    SE NÃO ENTENDER DE PRIMEIRA, CONTINUE TENTANDO ENTENDER NA 2ª, 3ª, 4ª... (LEIA VÁRIAS VEZES)
//   / /\ \ | |  |  __| | . ` | |      / _ \| |  | |    CONDICIONE SEU CÉREBRO A TENTAR O MÁXIMO, NÃO DEPENDER DOS OUTROS E NÃO DESISTIR POR ACHAR DÍFICIL
//  / ____ \| |  | |____| |\  | |____ / ___ \ |__| |    
// /_/    \_\_|  |______|_| \_|\_____/_/   \_\____/     ESPERO QUE AJUDE! 😘
                                                  
                                                  



//======================================================| 4 |====================================================
List list = new List(); // Criando uma lista vazia

// Criando alguns clientes
Cliente c1 = new Cliente();
c1.Nome = "Maycon";
c1.Cpf = "123.123.123-00";
Cliente c2 = new Cliente();
c2.Nome = "Bruno";
c2.Cpf = "123.123.123-01";
Cliente c3 = new Cliente();
c3.Nome = "Bertulino";
c3.Cpf = "123.123.123-02";

// Adicionando os clientes na lista
list.Add(c1);
list.Add(c2);
list.Add(c3);

Console.WriteLine(list.FindNome("123.123.123-01")); // Procurando por um cliente com o cpf 123.123.123-01



//======================================================| 3 |====================================================
public class List                                   // Criando nossa classe de lista, a responsabilidade dela é agrupar, adicionar, achar os valores pra gente
{
    private Node? root = null;                      // Dizendo que o primeiro item (root) dessa lista, o List.root (root é um objeto do tipo Node), começa valendo null. Pq não tem nada

    public void Add(Cliente cliente)                // Criando método para adicionar clientes, recebe um cliente como parametro
    {
        if (root == null)                           // Se o primeiro item (root) da lista estiver/for vazio...
        {
            root = new Node(cliente);               // Vamos definir que o cliente (qualquer objeto do tipo Cliente) que passamos como paramentro para o List.Add(cliente), vai ser o nosso root
            return;                                 // Como já adicionamos, com o return, encerramos a função. A partir de agora, o primeiro item, o root não vai mais ser null, vai ser o Node COM o nosso cliente
        }

        Node current = root;                        // Caso não tenhamos o root como null, vamos correr pela nossa lista, do primeiro item (root) até o último.
        while(!(current.Next is null))              // Como vamos 1 por 1, definimos current apontando pro primeiro item e vamos sempre apontando para o próximo, até que o próximo seja nulo (até que current.Next == null)
        {
            current = current.Next;
        }

        current.Next = new Node(cliente);           // Chegando no ultimo Node, colocamos outro node dentro dele, que vai ser o nosso Next e nosso novo último item.
    }
    public string FindNome(string cpf)              // Criando o método FindNome (Lista.FindNome("cpf")). Esse método recebe um cpf em string como parametro e vai procura-lo na nossa lista.
    {

        if (root == null)                           // Verificação pra ver se nossa lista não está vazia. Se estiver, avisa que não nenhum cliente.
        {
            return "Nenhum cliente cadastrado";
        }

        Node? current = root;                       // Mesmo processo de verificar um por um.

        while (current is not null)                 // Como agora queremos ver todos os itens da lista, e NÃO adicionar APÓS o último (Usem a cabeça pra pensar nessa lógica), vamos usar o current e não o current.Next
        {
            if (current.Value?.Cpf == cpf)          // Se o CPF (.Cpf) do nosso CLIENTE (.Value) do nosso NODE ATUAL (current) no loop for igual ao cpf que passamos como parametro...
            {
                return current.Value.Nome;          // Retornamos o NOME (.Nome) do nosso CLIENTE (.Value) do nosso NODE ATUAL (current) no loop. (O return interrompe o loop)
            }
            current = current.Next;                 // Se não o for o cpf que procuramos, andamos um Node pra frente e seguimos no loop até que verifiquemos todos
        }

        return "Não encontrado";                    // Completando o loop e não tendo encontrado nada, dizemos que não encontramos
    }
}


//======================================================| 2 |====================================================
// Criando a classe Node, que recebe cliente como atributo, com o nome de Value (Node.Value é um item do tipo Cliente)
// e tem um outro Node que recebe o nome de Next (Node.Next é um item do tipo node)
public class Node
{
    public Node(Cliente value)  // Construtor do node recebendo o cliente
    => this.Value = value;      // Salvando o cliente que passei para o node como Value

    public Cliente Value {get; set;}        // Criando o método pra poder editar e visualizar os dados do cliente com get e set
    public Node? Next {get; set;} = null;   // Criando o atributo com nome de Next. Que recebe um Node como valor. Como inicialmente não tem ninguém depois dele o Node.Next começa valendo null
}  


// ======================================================| 1 |====================================================
// Criando a classe Cliente
public class Cliente
{

    // Definindo valores padrão para não precisar tratar null
    private long cpf = 0;
    private string nome = "";

    // Definindo get e set para o nome privado
    public string Nome {
        get{return this.nome;}
        set{this.nome = value;}}

    // Definindo get e set para o cpf privado, que salvo como long
    public string Cpf{
        get { 
            string tempCpf = this.cpf.ToString();                           // pega o cpf como long e converte para string
            while (tempCpf.Length<11) tempCpf = tempCpf.Insert(0,"0");      // adiciona zeros na frente, pois o cpf precisa ter 11 digitos. Ex.: 22308212 => 00022308212
            return tempCpf.Insert(9,"-").Insert(6,".").Insert(3,"."); }     // adiciona pontuação e retorna no get

        set { this.cpf = long.Parse(value.Replace(".","").Replace("-","")); }  // remove os "." e "-", depois converte para long e salva
    }
}