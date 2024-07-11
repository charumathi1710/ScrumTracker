using ScrumTracker.BAL.ICustomLayer;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.CustomLayer
{
    public class RefreshTokenBal:IRefreshTokenBal
    {
        private IUnitofData UnitofData { get; }
        public RefreshTokenBal(IUnitofData unitofData)
        {
            UnitofData = unitofData;
        }
        public TokenResponse GenerateTokens(UserTokenEntity user)
        {
            return UnitofData.RefreshTokenDal.GenerateTokens(user);
        }
        public TokenResponse RefreshToken(string refreshToken)
        {
            return UnitofData.RefreshTokenDal.RefreshToken(refreshToken);
        }
    }
}
