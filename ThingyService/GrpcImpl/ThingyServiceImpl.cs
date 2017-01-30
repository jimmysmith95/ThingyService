using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Thingy;
using ThingyService.Repositories;

namespace ThingyService.GrpcImpl
{
    class ThingyServiceImpl : Thingy.ThingyService.ThingyServiceBase
    {
        private ThingyRepository repository;

        public ThingyServiceImpl(ThingyRepository repository)
        {
            this.repository = repository;
        }

        public async override Task<Thingy.Thingy> GetThingy(GetThingyRequest request, ServerCallContext context)
        {
            Models.Thingy thingy = await repository.Find(request.Id);
            if (thingy == null)
            {
                Console.WriteLine("Thingy was null.");
                return null;
            }
            else
            {
                Console.WriteLine("Thingy id: " + thingy.Id);
                Console.WriteLine("Thingy name: " + thingy.Name);
            }
            return new Thingy.Thingy { Id = thingy.Id, Name = thingy.Name };
        }
    }
}
