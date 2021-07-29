using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIStandart.Areas.ysadmin.ClaimsRepository
{
    public class ClaimsRepository : IClaimsService
    {
        public static List<ClaimModel> ClaimsList = new List<ClaimModel>(){
        new ClaimModel(){Id="1",Type="Administrator", Value="administrator"},
        new ClaimModel(){Id="2",Type="Sınırlı Yetki", Value="sinirliyetki"},
        new ClaimModel(){Id="3",Type="Create", Value="create"},
        new ClaimModel(){Id="4",Type="Edit", Value="edit"},
        new ClaimModel(){Id="5",Type="Delete", Value="delete"},
        new ClaimModel(){Id="6",Type="List", Value="list"},
          };

        public List<ClaimModel> GetAllClaims()
        {
            return ClaimsList;
        }
        public ClaimModel GetClaimsById(string Id)
        {
            return ClaimsList.Find(result => result.Id == Id);
        }
        public ClaimModel GetClaimsByType(string Type)
        {
            return ClaimsList.Find(result => result.Type == Type);
        }
        public ClaimModel GetClaimsByValue(string Value)
        {
            return ClaimsList.Find(result => result.Value == Value);
        }
    }
}
