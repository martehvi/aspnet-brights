﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Conduit.Domain.Entities;

namespace Conduit.Application.Features.Orders.Queries;
public class OrderDto
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public virtual required Article Article { get; set; }

    public int UserId { get; set; }
    public virtual required User User { get; set; }

    public bool Physical { get; set; }
    public string? SnailMail { get; set; }
    public decimal TotalPrice { get; set; }
}

public static class OrderMapper
{
    public static OrderDto Map(this Order order)
    {
        return new()
        {
            Id = order.Id,
            ArticleId = order.ArticleId,
            Article = order.Article,
            UserId = order.UserId,
            User = order.User,
            Physical = order.Physical,
            SnailMail = order.SnailMail,
            TotalPrice = order.TotalPrice
        };
    }
}