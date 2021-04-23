using System;
namespace webAuth
{
    public interface authenticationManager
    {
        string Authenticate(string username, string password);
    }
}
