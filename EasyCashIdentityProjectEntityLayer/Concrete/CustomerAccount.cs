using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProjectEntityLayer.Concrete
{
    public class CustomerAccount
    {
        public Guid CustomerAccountId { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string CustomerAccountCurrency { get; set;}
        public decimal CustomerAccountBalance{ get; set; }
        public string BankBranch { get; set; }
        public Guid AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
