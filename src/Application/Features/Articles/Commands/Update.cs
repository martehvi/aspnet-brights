using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Articles.Queries;
using Application.Interfaces;

namespace Application.Features.Articles.Commands
{
    public class ArticleUpdateDTO
    {
        public string Body { get; set; }
    }

    public record ArticleUpdateCommand(string slug, ArticleUpdateDTO Article) : IAuthorizationRequest<ArticleEnvelope>;

    public class ArticleUpdateHandler : IAuthorizationRequestHandler<ArticleUpdateCommand, ArticleEnvelope>
    {
        public Task<ArticleEnvelope> Handle(ArticleUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}