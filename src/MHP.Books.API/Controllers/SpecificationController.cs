using AutoMapper;
using MHP.Books.Business.Interfaces;

namespace MHP.Books.API.Controllers
{
    public class SpecificationController : MainController
    {
       /* private readonly ISpecificationRepository _specificationRepository;    */ 
        private readonly IMapper _mapper;

        public SpecificationController(/*ISpecificationRepository specificationRepository,*/
                                      IMapper mapper,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
           /* _specificationRepository = specificationRepository;*/
            _mapper = mapper;       
        }
    }
}