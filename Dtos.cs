using System;
using System.ComponentModel.DataAnnotations;

namespace Play.Identity
{
    public record UserDto(
        Guid Id,
        string Username,
        string Email,
        DateTimeOffset CreatedOn,
        decimal Cash
    );

    public record UpdateUserDto(
        [Required] string Id,
        [Required][EmailAddress] string Email,
        [Range(0, 10000)] decimal Cash
    );
}