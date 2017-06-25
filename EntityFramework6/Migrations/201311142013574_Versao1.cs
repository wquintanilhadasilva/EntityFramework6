namespace EntityFramework6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.historicos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        data_acao = c.DateTime(nullable: false),
                        acao = c.String(),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 20),
                        Senha = c.String(nullable: false, maxLength: 15),
                        PessoaID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.pessoas", t => t.PessoaID)
                .Index(t => t.PessoaID);
            
            CreateTable(
                "dbo.perfis",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.pessoas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 100),
                        nascimento = c.DateTime(),
                        sexo_masculino = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PerfilUsuarios",
                c => new
                    {
                        Perfil_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Perfil_Id, t.Usuario_Id })
                .ForeignKey("dbo.perfis", t => t.Perfil_Id, cascadeDelete: true)
                .ForeignKey("dbo.usuarios", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Perfil_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.usuarios", "PessoaID", "dbo.pessoas");
            DropForeignKey("dbo.PerfilUsuarios", "Usuario_Id", "dbo.usuarios");
            DropForeignKey("dbo.PerfilUsuarios", "Perfil_Id", "dbo.perfis");
            DropForeignKey("dbo.historicos", "UsuarioId", "dbo.usuarios");
            DropIndex("dbo.usuarios", new[] { "PessoaID" });
            DropIndex("dbo.PerfilUsuarios", new[] { "Usuario_Id" });
            DropIndex("dbo.PerfilUsuarios", new[] { "Perfil_Id" });
            DropIndex("dbo.historicos", new[] { "UsuarioId" });
            DropTable("dbo.PerfilUsuarios");
            DropTable("dbo.pessoas");
            DropTable("dbo.perfis");
            DropTable("dbo.usuarios");
            DropTable("dbo.historicos");
        }
    }
}
