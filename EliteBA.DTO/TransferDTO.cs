using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteBA.DTO
{
    public record TransferDTO(string senderAcc, string receiverAcc, double amount ,string narration);

}
