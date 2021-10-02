using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Features.Profiles.Commands;
using Application.Features.Profiles.Queries;
using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Application.IntegrationTests.Profiles
{
    public class ProfileFollowTests : TestBase
    {
        public ProfileFollowTests(Startup factory, ITestOutputHelper output) : base(factory, output) { }

        [Fact]
        public async Task Guest_Cannot_Follow_Profile()
        {
            await this.Invoking(x => x.Act(new ProfileFollowRequest("john", true)))
                .Should().ThrowAsync<UnauthorizedException>();
        }

        [Fact]
        public async Task Can_Follow_Profile()
        {
            await ActingAs(new User
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
            });

            await Context.Users.AddRangeAsync(
                new User
                {
                    Name = "Jane Doe",
                    Email = "jane.doe@example.com",
                },
                new User
                {
                    Name = "Alice",
                    Email = "alice@example.com",
                }
            );
            await Context.SaveChangesAsync();

            var response = await Act(new ProfileFollowRequest("Jane Doe", true));

            response.Profile.Should().BeEquivalentTo(new ProfileDTO
            {
                Username = "Jane Doe",
                Following = true
            });

            (await Context.Set<FollowerUser>().CountAsync()).Should().Be(1);
            (await Context.Set<FollowerUser>().AnyAsync(x => x.Following.Name == "Jane Doe"))
                .Should().BeTrue();
        }

        [Fact]
        public async Task Can_Unfollow_Profile()
        {
            await ActingAs(new User
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Following = new List<FollowerUser>
                {
                    new FollowerUser
                    {
                        Following = new User
                        {
                            Name = "Jane Doe",
                            Email = "jane.doe@example.com",
                        }
                    },
                    new FollowerUser
                    {
                        Following = new User
                        {
                            Name = "Alice",
                            Email = "alice@example.com",
                        }
                    }
                }
            });

            var response = await Act(new ProfileFollowRequest("Jane Doe", false));

            response.Profile.Should().BeEquivalentTo(new ProfileDTO
            {
                Username = "Jane Doe",
                Following = false
            });

            (await Context.Set<FollowerUser>().CountAsync()).Should().Be(1);
            (await Context.Set<FollowerUser>().AnyAsync(x => x.Following.Name == "Alice"))
                .Should().BeTrue();
        }
    }
}
