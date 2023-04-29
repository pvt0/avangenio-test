﻿using System.ComponentModel.DataAnnotations;

namespace Api.CQRS.UserRequests.GetContactById;

public class GetUserByIdDto
{
	public Guid Id { get; set; } 

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string Email { get; set; }

	public string UserName { get; set; }
}