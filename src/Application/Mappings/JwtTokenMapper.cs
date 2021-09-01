using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class JwtTokenMapper : IValueResolver<User, object, string>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public JwtTokenMapper(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        string IValueResolver<User, object, string>.Resolve(User source, object destination, string destMember, ResolutionContext context)
        {
            return _jwtTokenGenerator.CreateToken(source);
        }
    }
}