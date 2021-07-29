using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIStandart.Areas.ysadmin.ClaimsRepository
{
    interface IClaimsService
    {
        List<ClaimModel> GetAllClaims();
        ClaimModel GetClaimsById(string Id);
        ClaimModel GetClaimsByType(string Type);
        ClaimModel GetClaimsByValue(string Value);
    }
}
