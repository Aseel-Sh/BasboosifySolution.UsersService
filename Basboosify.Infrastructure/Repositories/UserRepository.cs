using Basboosify.Core.DTO;
using Basboosify.Core.Entities;
using Basboosify.Core.RepositoryContracts;
using Basboosify.Infrastructure.DbContext;
using Dapper;

namespace Basboosify.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{

    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //generate a new unique user id for the user
        user.UserID = Guid.NewGuid();

        //sql query to insert user data into users table
        string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES (@UserID, @Email, @PersonName, @Gender, @Password)";

        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
        if (rowCountAffected > 0)
        {
            return user;
        } else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        var param = new { Email = email, Password = password };
        //sql query to select user by email
        string query = "SELECT * FROM public .\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, param);
        
        return user;
    }
}
