using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteBA.DTO
{
    public record CreateAccountDto(string firstname, string lastname, string accountType);
    public record CreateCustomerAccountDto(string firstname, string lastname, string PhoneNo, string email, string address, string accountType = "Savings");
}
