using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeRate.Models.Common;

namespace ExchangeRate.Models.Entities
{
    public class EFToken : IToken
    {
        private TokenDbContext context;

        public EFToken(TokenDbContext context) => this.context = context;

        public IEnumerable<MetaData> MetaDatas => context.MetaData;
    }
}
