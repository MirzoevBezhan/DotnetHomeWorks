using Dapper;
using Domain;
using Npgsql;

namespace Infastructure;

public class MemberService : IMemberService
{
    private string connectionString = "Host=localhost;Username=postgres;Password=ipo90;DataBase=library_db";
    public int AddMember(Members members)
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "insert into members (fullname,phone,email,membershipdate) values(@fullname , @phone, @email , @membershipdate)";
            var res = com.Execute(cmd, members);
            return res;
        }
    }
    public List<Members> GetAllMember()
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select * from members";
            var res = com.Query<Members>(cmd).ToList();
            return res;
        }
    }
    public Members GetMemberById(int memberId)
    {
        using (var com = new NpgsqlConnection(connectionString))
        {
            com.Open();
            var cmd = "select * from members where memberId = @memberId";
            var res = com.QuerySingle<Members>(cmd, new { memberId = memberId });
            return res;
        }
    }
    public int UpdateMember(Members members)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "update books set fullname = @fullname, phone = @phone, email = @email , membershipDate = @membershipDate where MemberId = @MemberId";
            var result = con.Execute(cmd, members);
            return result;
        }
    }
    public int DeleteMember(int num)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            var cmd = "delete from members where MemberId = @MemberId";
            var result = con.Execute(cmd, num);
            return result;
        }
    }
}
