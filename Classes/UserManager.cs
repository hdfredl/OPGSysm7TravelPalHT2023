using System.Collections.Generic;

namespace OPGSysm7TravelPalHT2023.Classes;

public class UserManager
{
    public List<IUser> users = new List<IUser>();
    public IUser signInUser = null;

    public void AddUser(IUser user)
    {
        if (user == null)
        {
            users.Add(user); // lägger till user till users listan. 
        }
    }

    public void RemoveUser(IUser user)
    {
        users.Remove(user);
    }

    public bool UpdateUsername(IUser user, string newUser)
    {
        if (user != null && !string.IsNullOrEmpty(user.Username))
        {
            user.Username = newUser;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool signedInUser(string username, string password)
    {
        foreach (IUser user in users)
        {
            if (user.Username == username && user.Password == password)
            {
                signInUser = user;
                return true;
            }
        }
        return false;
    }

}
