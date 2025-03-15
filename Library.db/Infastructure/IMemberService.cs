namespace Infastructure;
using Domain;
public interface IMemberService
{
      public int AddMember(Members members);
    public List<Members> GetAllMember();
    public Members GetMemberById(int memberId);
    public int UpdateMember(Members members);
    public int DeleteMember(int num);
}
