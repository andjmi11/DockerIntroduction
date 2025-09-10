﻿using BlogAPI.Features.Authors.Commands;
using BlogAPI.Features.Authors.DTOs;
using BlogAPI.Models;

namespace BlogAPI.Features.Authors.Mapping
{
    public static class AuthorExtensions
    {
        public static AuthorDTO ToDto(this Author author) =>
            new AuthorDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
            };

        public static CreateAuthorCommand ToCreateCommand(this AuthorDTO dto) =>
            new CreateAuthorCommand
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
    }
}
