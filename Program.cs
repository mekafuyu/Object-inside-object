// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
List list = new List();

Cliente c1 = new Cliente();
c1.Nome = "Maycon";
c1.Cpf = "133.575.749-00";
Cliente c2 = new Cliente();
c2.Nome = "Bruno";
c2.Cpf = "133.375.749-00";
Cliente c3 = new Cliente();
c3.Nome = "Bertulino";
c3.Cpf = "133.475.749-00";

list.Add(c1);
list.Add(c2);
list.Add(c3);

Console.WriteLine(list.FindNome("133.375.749-00"));


public class List
{
    private Node? root = null;

    public void Add(Cliente cliente)
    {
        if (root == null)
        {
            root = new Node(cliente);
            return;
        }

        Node current = root;

        while(!(current.Next is null))
        {
            current = current.Next;
        }

        current.Next = new Node(cliente); 
    }
    public string FindNome(string cpf)
    {
        if (root == null)
        {
            return "Nenhum cliente cadastrado";
        }

        Node? current = root;

        while (current is not null)
        {
            if (current.Value?.Cpf == cpf)
            {
                return current.Value.Nome;
            }
            current = current.Next;
        }


        return "Não encontrado";
    }
}

public class Node
{
    public Node(Cliente value)
    => this.Value = value;

    public Cliente Value {get; set;}
    public Node? Next {get; set;} = null;
}


public class Cliente
{
    private long cpf = 0;
    private string nome = "";


    public string Nome {
        get{return this.nome;}
        set{this.nome = value;}}

    public string Cpf{
        get { 
            string tempCpf = this.cpf.ToString();
            while (tempCpf.Length<11) tempCpf = tempCpf.Insert(0,"0");
            return tempCpf.Insert(9,"-").Insert(6,".").Insert(3,"."); }
        set { this.cpf = long.Parse(value.Replace(".","").Replace("-","")); }
    }
}


