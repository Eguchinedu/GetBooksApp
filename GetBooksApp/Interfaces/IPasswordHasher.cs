﻿namespace GetBooksApp.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string inputPassword);
    }
}
