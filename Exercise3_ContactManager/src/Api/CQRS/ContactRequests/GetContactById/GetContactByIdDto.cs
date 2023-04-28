﻿namespace Api.CQRS.ContactRequests.GetContactById;

public class GetContactByIdDto
{
	public Guid Id { get; set; }

	public string FirstName { get; set; }

	public string? LastName { get; set; }

	public string Email { get; set; }

	public DateTime DateOfBirth { get; set; }

	public int Age { get; set; }

	public string Phone { get; set; }

	public Guid Owner { get; set; }
}