﻿using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record CreateBookOnShelvesCommand(BookOnShelvesCreateDto BookOnShelvesCreateDto) : IRequest<int>;
}
