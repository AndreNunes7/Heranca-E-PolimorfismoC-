// OBS: classe genérica

using System.Text;
using System.Threading.Channels;

namespace Figura2
{
    // Construtor da superclasse
    public abstract class Pessoa // Classe abstrata não pode ser instanciada
    {

        private DateTime dataNascimento;
        //private string rg;
        //private string cpf;
        //private char sexo; // "F" e "M"

        private List<string> telefones = new List<string>(); // Lista de telefones

        public abstract float Salario(float valor, float quantidade);

        public void AdicionarTelefone(string tel)
        {
            telefones.Add(tel); // Adicionando o valor à lista
        }

        public string ListaTelefones()
        {
            StringBuilder ret = new StringBuilder();
            foreach (string tel in telefones)
            {
                ret.AppendLine(tel);
            }
            return ret.ToString();
        }

        public string Tipo { get; protected set; } // Somente subclasses podem alterar o nome

        public string Nome
        {
            get;
        }
        public DateTime DataNascimento
        {
            get;
        }
        public string Cpf
        {
            get;
        }

        public string Rg
        {
            get;
        }
        public char Sexo
        {
            get;
        }

        // Propriedades privadas e métodos públicos

        public Pessoa(string nome, DateTime dataNascimento, string Rg, string Cpf, char sexo) // Construtor
        {
            this.Tipo = "Aluno";
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Rg = Rg;
            this.Cpf = Cpf;
            this.Sexo = sexo;
        }

        // Sobrescrevendo o método ToString
        public override string ToString() // Superclasse Pessoa
        {
            return string.Concat(
                "Tipo: ", Tipo,
                "\nNome: ", Nome,
                "\nNascimento: ", DataNascimento.ToString("dd/MM/yyyy"),
                "\nRG: ", Rg,
                "\nCPF: ", Cpf,
                "\nSexo: ", Sexo);
        }
    }

    public class Professor : Pessoa
    {
        public string RegFunc { get; }
        public string Formacao { get; }

        public Professor(string nome, DateTime dataNascimento, string rg, string cpf, char sexo,
        string regFunc, string formacao) : base(nome, dataNascimento, rg, cpf, sexo)
        {
            this.RegFunc = regFunc;
            this.Formacao = formacao;
            this.Tipo = "Professor";
        }

        public override float Salario(float valor, float quantidade)
        {
            return valor * quantidade;
        }

        public override string ToString()
        {
            return string.Concat(

                base.ToString(),
                "\nReg.Func: ", RegFunc,
                "\nFormação: ", Formacao,
                "\nTelefone: ", ListaTelefones());

        }
    }

    public class Aluno : Pessoa
    {
        public string Ra { get; }
        public string Curso { get; }

        public Aluno(string nome, DateTime dataNascimento, string rg, string cpf, char sexo, string ra, string curso)
            : base(nome, dataNascimento, rg, cpf, sexo)
        {
            this.Ra = ra;
            this.Curso = curso;
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), "\nCurso: ", Curso, "\nRA: ", Ra, "\nTelefone: ", ListaTelefones());
        }

        public override float Salario(float valor, float quantidade)
        {
            return 0;
        }
    }

    public class Funcionario : Pessoa
    {
        private string cargo = string.Empty;

        public string Cargo
        {
            get
            {
                return cargo;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentNullException("Cargo não pode estar em branco!"); // Tratamento de exceção
                }
                cargo = value;
               
            }
        }

        public DateTime DataAdmissao { get; }

        public string RegFunc { get; }

        public Funcionario(string nome, DateTime dataNascimento, string rg, string cpf, char sexo, string cargo, string RegFunc)
            : base(nome, dataNascimento, rg, cpf, sexo)
        {
            this.Cargo = cargo;
            this.DataAdmissao = DateTime.Now; // Alterei para DateTime.Now, você pode ajustar conforme necessário.
            this.Tipo = "Funcionario";
            this.RegFunc = RegFunc;
        }

        public override string ToString()
        {
            return string.Concat(

                base.ToString(),
                "\nReg.Func: ", RegFunc,
                "\nData de admissão: ", DataAdmissao,
                "\nCargo: ", Cargo,
                "\nTelefone: ", ListaTelefones());


        }

        public override float Salario(float valor, float quantidade)
        {
            return valor;
        }
    }

    public class Noia : Pessoa
    {
        public Noia(string nome, DateTime dataNascimento, string rg, string cpf, char sexo)
            : base(nome, dataNascimento, rg, cpf, sexo)
        {
            Tipo = "Noia";
        }

        public override float Salario(float valor, float quantidade)
        {
            return 0;
        }
    }

    // Main
    public class Programa
    {
        public static int Main(string[] args)
        {
            Aluno a1 = new Aluno("Andre", new DateTime(2004, 02, 12), "42424242435", "332-321-313-1", 'M', "228290", "ADS");
            a1.AdicionarTelefone("1399420425");

            Aluno a2 = new Aluno("Kayky", new DateTime(2003, 05, 15), "12304245255", "4492-4242-231", 'F', "330425", "Sistema da informação");
            a2.AdicionarTelefone("1499420425");
            Aluno a3 = new Aluno("Peterson", new DateTime(2001, 01, 25), "15020424052", "7742852-52324", 'F', "220425", "Educação física");
            a3.AdicionarTelefone("1699420525");
            Aluno a4 = new Aluno("Murilo", new DateTime(2002, 05, 23), "77432004222", "13994242042", 'F', "210425", "ADS");
            a4.AdicionarTelefone("1599424024");



            List<Aluno> list = new List<Aluno>();
            List<Pessoa> cargos = new List<Pessoa>();
            List<Funcionario> listaFuncionarios = new List<Funcionario>();

            Funcionario p1 = new Funcionario("Marcos", new DateTime(2004, 02, 12), "21093320913", "45356471866", 'M', "Padeiro", "229-342");
            listaFuncionarios.Add(p1);
            p1.AdicionarTelefone("178892324252");

            Funcionario p2 = new Funcionario("Raimundo", new DateTime(2001, 05, 13), "3334299823", "9998882222", 'M', "Aviaozinho", "333-555");
            listaFuncionarios.Add(p2);
            p2.AdicionarTelefone("445005205232");


            list.Add(a1);
            list.Add(a2);
            list.Add(a3);
            list.Add(a4);

            string leiaCargo = string.Empty;


            try
            {
                Console.WriteLine("Digite o cargo:");
                leiaCargo = Console.ReadLine();

                p1.Cargo = leiaCargo;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro aqui: (" + ex.Message);
                p1.Cargo = "VAZIO";
                p2.Cargo = "VAZIO";

            }

            try
            {
                Console.WriteLine("Digite outro cargo:");
                leiaCargo = Console.ReadLine();

                p2.Cargo = leiaCargo;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro aqui: (" + ex.Message);
                p2.Cargo = "VAZIO";
            }
          

            Noia n1 = new Noia("Celso", new DateTime(1992, 10, 05), "44928429420", "09804293232", 'M');
            Professor prof1 = new Professor("Rangel", new DateTime(1995, 01, 21), "552052525052", "13310202334", 'M', "32323223", "Engenharia Civil");

            prof1.AdicionarTelefone("13993222115");

            List<Pessoa> pessoas = new List<Pessoa>();

            pessoas.Add(prof1);
            pessoas.Add(a1);
            pessoas.Add(a2);
            pessoas.Add(a3);
            pessoas.Add(a4);
            pessoas.Add(p1);
            pessoas.Add(p2);
            pessoas.Add(n1);

            Console.WriteLine("-------------------------------");

            foreach (Pessoa p in pessoas)
            {
                Console.WriteLine(p.ToString());


                Console.WriteLine("-------------------------------");


            }
            return 0;
        }
    }
}
