using SimpleMigrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingyService.Migrations
{
    [Migration(1)]
    class Migration01 : Migration
    {
        public override void Up()
        {
            Execute("CREATE TABLE Thingy (Id int Identity(1,1) PRIMARY KEY, Name varchar(255) NOT NULL)");
        }

        public override void Down()
        {
            Execute("DROP TABLE Thingy");
        }
    }
}
