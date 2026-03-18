//loginViewModel can call UserStore.LoadUsers()
//so, we follow solid principles (S - principle)
//and login view model does have so many responsibilities as 
//loading json file, for example

//class that 1. work with user data
//2. loads users
//3. help validate login

//as we work with two user types - lets have too lists 
using LibraryApp.Models;

using System.Collections.Generic;

namespace LibraryApp.Repository;

public class UserStore
{
    public List<Member> Members { get; set; } = new List<Member>();
    public List<Librarian> Librarians{ get; set; } = new List<Librarian>();
}