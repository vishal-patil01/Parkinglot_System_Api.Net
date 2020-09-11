namespace ApplicationRepositoryLayer.Implementation
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using ApplicationModelLayer;
    using ApplicationRepositoryLayer.Interface;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;
        private readonly ILogger<UserRepository> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="configuration">Object Of Iconfiguration.</param>
        /// <param name="logger">Object Of Ilogger.</param>
        public UserRepository(IConfiguration configuration, ILogger<UserRepository> logger)
        {
            this.connectionString = configuration.GetSection("ConnectionStrings").GetSection("ParkingLotDBConnection").Value;
            this.connection = new SqlConnection(this.connectionString);
            this.logger = logger;
            var a = configuration["Jwt:Key"];
            Console.WriteLine(1);
        }

        public Boolean AddUser(Users userDetails)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAddUsers", this.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Role", userDetails.Roles);
                cmd.Parameters.AddWithValue("@Email", userDetails.Email);
                cmd.Parameters.AddWithValue("@Password", userDetails.Password);
                this.connection.Open();

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }

        public string Login(UserLogin userInfo)
        {
            string RoleName = "";
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", userInfo.Email);
                cmd.Parameters.AddWithValue("@Password", userInfo.Password);
                cmd.Parameters.Add("@Role", SqlDbType.NVarChar, 20);
                cmd.Parameters["@Role"].Direction = ParameterDirection.Output;
                con.Open();

                int result = cmd.ExecuteNonQuery();

                if (result < 0)
                {
                    RoleName = Convert.ToString(cmd.Parameters["@Role"].Value).Trim();
                    return RoleName;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
            return RoleName;
        }
    }
}
