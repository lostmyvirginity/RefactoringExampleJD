using LegacyApp;
using LegacyApp.Core.Validators;

namespace LegacyAppTests;

public class FakeClientRepository : IClientRepository
{
    public static readonly Dictionary<int, Client> Database = new Dictionary<int, Client>()
    {
        {1, new Client{ClientId = 1, Name = "Numernabis", Address = "Egipt", Email = "Numernabis@wp.pl", Type = "VeryImportantClient"}},
        {2, new Client{ClientId = 2, Name = "Marnypopis", Address = "Egipt", Email = "Marnypopis@gmail.pl", Type = "NormalClient"}},
        {3, new Client{ClientId = 3, Name = "Asterix", Address = "Galia", Email = "Asterix@gmail.pl", Type = "ImportantClient"}},
        {4, new Client{ClientId = 4, Name = "Obleix", Address = "Galia", Email = "Obleix@gmail.pl", Type = "ImportantClient"}},
        {5, new Client{ClientId = 5, Name = "Panoramix", Address = "Galia", Email = "Panoramix@wp.pl", Type = "NormalClient"}},
        {6, new Client{ClientId = 6, Name = "Idefix", Address = "Galia", Email = "Idefix@wp.pl", Type = "NormalClient"}}
    };
        
    public Client GetById(int clientId)
    {
        int randomWaitTime = new Random().Next(2000);
        Thread.Sleep(randomWaitTime);

        if (Database.ContainsKey(clientId))
            return Database[clientId];

        throw new ArgumentException($"User with id {clientId} does not exist in database");
    }
}
