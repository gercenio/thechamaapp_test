using DapperExtensions.Mapper;
using TheChamaApp.Domain.Entities;

namespace TheChamaApp.Infra.Data.Mapper
{
    public class UserMapper  : ClassMapper<User>
    {
        public UserMapper()
        {
            Table("TBLTENDAAPI_USUARIO");

            //Map(p => p.UserId).Column("UserId").Key(KeyType.Identity);
            Map(p => p.UserCode).Column("UserCode");
            Map(p => p.AccessKey).Column("AccessKey");
        }
    }
}
