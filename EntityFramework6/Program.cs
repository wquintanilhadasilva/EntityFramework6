using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework6
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new DataBaseContext())
            {

                exibirTudo(ctx);

                //inserirPerfil(ctx);
                //inserirUsuario(ctx);
                //inserirPessoa(ctx);

                //associaUsuarioAPefilSelectAntes(ctx);

                //associaUsuarioAPefilIdNoCodigo(ctx);               
                
                //Inserindo uma nova pessoa id = 1

                //Inserindo um novo usuario e indicando a pessoa acima


                //Atualizando o usuario 1 e associando uma nova pessoa id =2

                //Inserindo uma nova pessoa id = 3

                //inserindo um novo usuario

                //Atualizando o usuário acima com a pessoa acima id = 3

                //associaUsuarioAPessoa(ctx);

                //incluiHistorico(ctx);

                excluirHistoricoPorId(ctx);

                exibirTudo(ctx);

                Console.ReadKey();

            }            

        }

        static void inserirPerfil(DataBaseContext ctx)
        {
            //Inserindo um perfil
            var p1 = new Perfil
            {
                Descricao = "Perfil 2",
            };

            ctx.Perfis.Add(p1);
            ctx.SaveChanges();
        }

        static void inserirUsuario(DataBaseContext ctx)
        {
            //Inserindo um novo usuario
            var u1 = new Usuario
            {
                Login = "Usuario 1",
                Senha = "123",
            };

            ctx.Usuarios.Add(u1);
            ctx.SaveChanges();
        }

        static void inserirPessoa(DataBaseContext ctx)
        {
            //Inserindo uma nova pessoa
            var pessoa = new Pessoa
            {
                Masculino = true,
                Nome = "Pessoa 3",
                Nascimento = new DateTime(1977,12,13)
            };

            ctx.Pessoas.Add(pessoa);
            ctx.SaveChanges();
        }

        static void associaUsuarioAPefilIdNoCodigo(DataBaseContext ctx)
        {
            var p = new Perfil
            {
                Descricao = "Novo Perfil teste domingo",
            };

            var user = ctx.Usuarios.Where(u => u.Id == 1).First();

            user.Perfis.Add(p);

            ctx.Entry(user).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
           

        }

        static void associaUsuarioAPefilSelectAntes(DataBaseContext ctx)
        {
            var per = ctx.Perfis.Where(p => p.Id == 2).First();

            var user = ctx.Usuarios.Where(u => u.Id == 1).First();

            user.Perfis.Add(per);

            ctx.Entry(user).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();

        }

        static void associaUsuarioAPessoa(DataBaseContext ctx)
        {

            var pessoa = (from p in ctx.Pessoas where p.Id == 1 select p).FirstOrDefault();
            var usuario = (from u in ctx.Usuarios where u.Id == 1 select u).FirstOrDefault();

            usuario.Pessoa = pessoa;

            ctx.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        static void incluiHistorico(DataBaseContext ctx)
        {

            var user = (from u in ctx.Usuarios where u.Id == 1 select u).FirstOrDefault();

            for (int i = 0; i <= 10; i++)
            {
                var h = new HistoricoUsuario
                {
                    Acao = "ACAO: " + i,
                    Data = DateTime.Now,
                    Usuario = user
                };

                ctx.Historicos.Add(h);
            }
            ctx.SaveChanges();
        }

        static void excluirHistoricoPorId(DataBaseContext ctx)
        {
            var hist = (from h in ctx.Historicos where h.Id == 11 select h).FirstOrDefault();
            if (hist != null)
            {
                ctx.Entry(hist).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        private static void exibirTudo(DataBaseContext ctx)
        {
            var usu = ctx.Usuarios.Include("Perfis").Include("Pessoa");

            foreach (Usuario u in usu)
            {
                Console.WriteLine(String.Format("Usuário: {0} - Nome: {1}", u.Id, u.Login));
                if (u.Pessoa != null)
                {
                    Console.WriteLine(String.Format("Pessoa: {0}, Nome: {1}", u.Pessoa.Id, u.Pessoa.Nome));
                }

                foreach (Perfil p in u.Perfis)
                {
                    Console.WriteLine(String.Format("Perfil: {0} - Descricao: {1}", p.Id, p.Descricao));
                }

            }

            Console.WriteLine("------------------------- Pessoas --------------------------------");

            var pessoas = ctx.Pessoas;
            foreach (var p in pessoas)
            {
                Console.WriteLine(String.Format("Pessoa: {0}, Nome: {1}", p.Id, p.Nome));
            }

            Console.WriteLine("------------------------- Historico --------------------------------");

            foreach (HistoricoUsuario h in ctx.Historicos)
            {
                Console.WriteLine(String.Format("Histórico: {0} - Ação: {1}", h.Id, h.Acao));
            }

        }

        public void teste()
        {
            IList<Pessoa> listaDePessoas = new List<Pessoa>();

            var machos = from p in listaDePessoas where p.Nome.Equals("M") select p;


        }
    }
}
