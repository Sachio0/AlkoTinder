using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Persistence;
using System;
using MediatR;
using System.ComponentModel.Design;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Net;
using Application.Interfaces;

namespace Application
{
    public class Login
    {
        public class Query: IRequest<User>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(n => n.Email).NotEmpty();
                RuleFor(n => n.Password).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Query, User>
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _singInManager;
            private readonly IJwtGenerator _jwtGenerator;
            public Handler(UserManager<User> userManager, SignInManager<User> singInManager, IJwtGenerator jwtGenerator)
            {
                _userManager = userManager;
                _singInManager = singInManager;
                _jwtGenerator = jwtGenerator;
            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null) { }throw new Exception();//(HttpStatusCode.Unauthorized);
                var result = await _singInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (result.Succeeded)
                {
                    // TODO generet Token
                    return new User
                    {
                        DisplayName = user.DisplayName,
                        Image = null,
                        Token = _jwtGenerator.CreateToken(user),
                        UserName = user.UserName
                    };
                }
                throw new Exception();//(HttpStatusCode.Unauthorized);
            }
        }
    }
}
