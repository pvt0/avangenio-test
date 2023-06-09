﻿using System.Net;
using MediatR;

namespace Api.CQRS.UserRequests.GetUserById;

public class GetUserByIdQuery : IRequest<(HttpStatusCode status, GetUserByIdDto? userDto)>
{
	public Guid UserId { get; set; }

	public GetUserByIdQuery(Guid userId)
	{
		UserId = userId;
	}

}