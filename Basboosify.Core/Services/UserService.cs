using AutoMapper;
using Basboosify.Core.DTO;
using Basboosify.Core.Entities;
using Basboosify.Core.RepositoryContracts;
using Basboosify.Core.ServiceContracts;

namespace Basboosify.Core.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _usersRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
       ApplicationUser? user =  await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        //return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Success: true);
        return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
    }
     
    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //Create a new app user object from register request
        ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);


        ApplicationUser? registeredUser = await _usersRepository.AddUser(user);

        if (registeredUser == null) 
        {
            return null;
        }

        //return new AuthenticationResponse(registeredUser.UserID, registeredUser.PersonName, registeredUser.Email, registeredUser.Gender, "token", Success: true);
        return _mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token" };
    }
}
