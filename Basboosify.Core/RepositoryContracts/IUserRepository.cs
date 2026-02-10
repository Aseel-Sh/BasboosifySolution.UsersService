using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basboosify.Core.Entities;

namespace Basboosify.Core.RepositoryContracts;
/// <summary>
/// Contract to be implemented by UsersRepositor that contains data access logic of Users data store
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Method to add user to the data store and return added user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);

    /// <summary>
    /// Method to get exisitng user by their email and password
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

    /// <summary>
    /// returns the users data based on the given userID
    /// </summary>
    /// <param name="userID">User id to search for</param>
    /// <returns>applicationUser object that matches given id</returns>
    Task<ApplicationUser?> GetUserByUserID(Guid? userID);
}
