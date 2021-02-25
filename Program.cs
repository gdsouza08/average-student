using System;

namespace average_student
{
    class Program
    {
        static void Main(string[] args)
        {

            Aluno[] alunos = new Aluno [5];
            var indiceAluno = 0;

            string userOption = getUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        //TODO: adiciona aluno
                        Console.WriteLine("Informe o nome do aluno(a): ");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do(a) "+ $"{aluno.Nome}:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                        aluno.Nota = nota;
                        } else {
                            throw new ArgumentException("Valor da nota deve ser em decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        //TODO: lista aluno
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO(A): {a.Nome}, NOTA: {a.Nota}");
                            }
                        }
                        break;

                    case "3":
                        //TODO: calcula média geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal +alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;
                        if (mediaGeral <= 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral <= 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral <= 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral <= 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral}, Conceito da turma: {conceitoGeral}");


                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                userOption = getUserOption();

            }
        }

        private static string getUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine("[ 1 ] Adicionar aluno ");
            Console.WriteLine("[ 2 ] Listar alunos ");
            Console.WriteLine("[ 3 ] Calcular média geral ");
            Console.WriteLine("[ X ] Sair do programa ");
            Console.WriteLine();

            string userOption = Console.ReadLine();
            Console.WriteLine();
            return userOption;
        }
    }
}
