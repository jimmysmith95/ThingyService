using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Thingy;

namespace ThingyService.GrpcImpl
{
    class ThingyServiceImpl : Thingy.ThingyService.ThingyServiceBase
    {
        public override Task<Thingy.Thingy> GetThingy(GetThingyRequest request, ServerCallContext context)
        {
            return base.GetThingy(request, context);
        }
    }
}
