using API_CQS_CRUD_Usuarios.Domain.Queries.Results;
using MediatR;
using System.Collections.Generic;

namespace API_CQS_CRUD_Usuarios.Domain.Queries
{
    public class GetPagedUsuariosQuery : IRequest<IEnumerable<GetPagedUsersQueryResult>>
    {
        public GetPagedUsuariosQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; protected set; }
        public int PageSize { get; protected set; }

        public static GetPagedUsuariosQuery Create(int page, int pageSize)
            => new GetPagedUsuariosQuery(page, pageSize);
    }
}
