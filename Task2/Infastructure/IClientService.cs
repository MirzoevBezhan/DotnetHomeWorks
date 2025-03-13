using Npgsql;

namespace Infastructure;

using Domain;

public interface IClientService
{
    public void get();
     int addclient(Client client);
     List<Client> GetAllclients();
     Client getclientbyid(int client_id);
    public void updateclient(Client client);
     void deleteclient(int client_id);
     Client getrichesclient();
     int getclientcount();
     decimal getaveragebalance();
}