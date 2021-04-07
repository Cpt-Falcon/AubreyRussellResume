using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AubreyRussellServer.Utilities
{
    public class SqlDBManagerService
    {
        public SqlDBManagerService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private string ConnectionStr
        {
            get
            {
                return this.Configuration.GetConnectionString("SqlDemoConnection");
            }
        }

        public async Task InitDatabase()
        {
            using SqlConnection myConn = new SqlConnection(this.ConnectionStr);
            await myConn.OpenAsync();
            await myConn.ChangeDatabaseAsync("MySqlDemoTest");

            await this.ExecuteQuery("CREATE TABLE restaurants (restaurant_id int NOT NULL IDENTITY PRIMARY KEY, " +
                "name varchar(255) NOT NULL, address varchar(255) NOT NULL, sales int);", myConn);

            await this.ExecuteQuery("CREATE TABLE recipes (recipe_id int NOT NULL IDENTITY PRIMARY KEY, " +
    "name varchar(255) NOT NULL);", myConn);

            await this.ExecuteQuery("CREATE TABLE restaurants_recipes (restaurants_recipe_id int NOT NULL IDENTITY PRIMARY KEY, " +
"restaurant_id int FOREIGN KEY REFERENCES restaurants(restaurant_id), recipe_id int FOREIGN KEY REFERENCES recipes(recipe_id));", myConn);


            await this.ExecuteQuery("CREATE TABLE ingredients (ingredients_id int NOT NULL IDENTITY PRIMARY KEY, " +
"name varchar(255) NOT NULL, price int, recipe_id int FOREIGN KEY REFERENCES recipes(recipe_id));", myConn);

            await this.ExecuteQuery("CREATE TABLE employees (employees_id int NOT NULL IDENTITY PRIMARY KEY, " +
"name varchar(255) NOT NULL, salary int, restaurant_id int FOREIGN KEY REFERENCES restaurants(restaurant_id));", myConn);

            SqlCommand readCmd = new SqlCommand("SELECT restaurant_id FROM restaurants r WHERE r.name = 'testaurant';", myConn);
            var result = await readCmd.ExecuteReaderAsync();
            await result.ReadAsync();
            if (result.HasRows)
            {
                int restaurantId = (await readCmd.ExecuteReaderAsync()).GetInt32(0);
                await this.ExecuteQuery("INSERT INTO employees (name, salary, restaurant_id) VALUES ('test employee', '100', " + restaurantId + ");", myConn);
            }
            else
            {
                await this.ExecuteQuery("INSERT INTO restaurants (name, address, sales) VALUES ('testaurant', '123 test addr', '9001');", myConn);
            }



            await myConn.DisposeAsync();
        }

        private async Task ExecuteQuery(string commandStr, SqlConnection myConn)
        {
            try
            {
                SqlCommand command = new SqlCommand(commandStr, myConn);
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                // Handle failure case later.
            }
        }

    }
}
