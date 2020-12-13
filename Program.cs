using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = Program.Menu();
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }          

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} = NOTA: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaSoma = 0;
                        var nrAlunos = 0;
                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaSoma += alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        decimal media = notaSoma/nrAlunos;
                        Conceito conceitoGeral;
                        if (media < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (media < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (media < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (media < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {media} - CONCEITO GERAL: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = Program.Menu();
                Console.WriteLine();
            }
        }
        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
