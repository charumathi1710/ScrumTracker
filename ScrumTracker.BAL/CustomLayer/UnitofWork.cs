using ScrumTracker.BAL.ICustomLayer;

namespace ScrumTracker.BAL.CustomLayer
{
    public class UnitofWork:IUnitofWork
    {
        public UnitofWork(IUserServiceBal userService)
        {
            UserServiceBal = userService;
        }
        public IUserServiceBal UserServiceBal { get; }
    }
}
