using AskToniApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Options;

public class UserRepository : IUserRepository
{
    private readonly AskToniContext _context = null;

    public UserRepository(IOptions<DbConnectionConfig> dbConnectionConfig)
    {
        DbConnectionConfig _dbConnectionConfig = dbConnectionConfig.Value;
        _context = new AskToniContext(_dbConnectionConfig.mLabConnectStr);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        try {
            return await _context.Users.Find(_ => true).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task AddUser(User item)
    {
        await _context.Users.InsertOneAsync(item);
    }
}