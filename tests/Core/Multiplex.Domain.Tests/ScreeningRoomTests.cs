using Bogus;
using Bogus.Extensions;
using Shouldly;
using System;

namespace Multiplex.Domain.Tests;

public class ScreeningRoomTests
{

    [Fact]
    public void Valid_New_ScreeningRoom()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    f.Lorem.Sentence().ClampLength(1, 50)
                )
            );

        var fakeScreeningRoom = fakerScreeningRoom.Generate();

        var screeningRoom = new ScreeningRoom(fakeScreeningRoom.Number, fakeScreeningRoom.Description);

        screeningRoom.ShouldSatisfyAllConditions(
            () => screeningRoom.Number.ShouldBe(fakeScreeningRoom.Number),
            () => screeningRoom.Description.ShouldBe(fakeScreeningRoom.Description));
    }

    [Fact]
    public void Valid_New_ScreeningRoom_Add_Movie()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    f.Lorem.Sentence().ClampLength(1, 50)
                )
            );

        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    f.Name.FullName().ClampLength(1, 50),
                    f.Random.Int(0, 100)
                )
            )
            .RuleFor(m => m.Id, f => f.Random.Guid());

        var fakeMovie = fakerMovie.Generate();

        var fakeScreeningRoom = fakerScreeningRoom.Generate();

        fakeScreeningRoom.AddMovie(fakeMovie);

        fakeScreeningRoom.ShouldSatisfyAllConditions(
            () => fakeScreeningRoom.Movies.Contains(fakeMovie).ShouldBe(true));
    }

    [Fact]
    public void Valid_New_ScreeningRoom_Contains_Movie()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    f.Lorem.Sentence().ClampLength(1, 50)
                )
            );

        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    f.Name.FullName().ClampLength(1, 50),
                    f.Random.Int(0, 100)
                )
            )
            .RuleFor(m => m.Id, f => f.Random.Guid());

        var fakeMovie = fakerMovie.Generate();

        var fakeScreeningRoom = fakerScreeningRoom.Generate();

        fakeScreeningRoom.AddMovie(fakeMovie);

        fakeScreeningRoom.ShouldSatisfyAllConditions(
            () => fakeScreeningRoom.ContainsMovie(fakeMovie.Id).ShouldBe(fakeMovie));
    }

    [Fact]
    public void Valid_New_ScreeningRoom_Remove_Movie()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    f.Lorem.Sentence().ClampLength(1, 50)
                )
            );

        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    f.Name.FullName().ClampLength(1, 50),
                    f.Random.Int(0, 100)
                )
            )
            .RuleFor(m => m.Id, f => f.Random.Guid());

        var fakeMovie = fakerMovie.Generate();

        var fakeScreeningRoom = fakerScreeningRoom.Generate();

        fakeScreeningRoom.AddMovie(fakeMovie);
        fakeScreeningRoom.RemoveMovie(fakeMovie);

        fakeScreeningRoom.ShouldSatisfyAllConditions(
            () => fakeScreeningRoom.Movies.ShouldBeEmpty());
    }

    [Fact]
    public void Invalid_New_ScreeningRoom_Description_Null()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    null!
                )
            );

        Should.Throw<ArgumentException>(() => fakerScreeningRoom.Generate());
    }

    [Fact]
    public void Invalid_New_ScreeningRoom_Description_Empty()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    string.Empty
                )
            );

        Should.Throw<ArgumentException>(() => fakerScreeningRoom.Generate());
    }

    [Fact]
    public void Invalid_New_ScreeningRoom_Description_White_Space()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    " "
                )
            );

        Should.Throw<ArgumentException>(() => fakerScreeningRoom.Generate());
    }

    [Fact]
    public void Invalid_New_ScreeningRoom_Description_Large()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    f.Lorem.Sentences(10)
                )
            );

        Should.Throw<ArgumentException>(() => fakerScreeningRoom.Generate());
    }

    [Fact]
    public void Invalid_New_ScreeningRoom_Duration_Less_Then_One()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(-100, 0),
                    f.Lorem.Sentence().ClampLength(1, 50)
                )
            );

        Should.Throw<ArgumentException>(() => fakerScreeningRoom.Generate());
    }

    [Fact]
    public void Invalid_New_ScreeningRoom_Add_Movie_Null()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    f.Lorem.Sentence().ClampLength(1, 50)
                )
            );

        var fakeScreeningRoom = fakerScreeningRoom.Generate();

        Should.Throw<ArgumentException>(() => fakeScreeningRoom.AddMovie(null!));
    }

    [Fact]
    public void Invalid_New_ScreeningRoom_Add_Movie_Duplicated()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    f.Lorem.Sentence().ClampLength(1, 50)
                )
            );

        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    f.Name.FullName().ClampLength(1, 50),
                    f.Random.Int(0, 100)
                )
            )
            .RuleFor(m => m.Id, f => f.Random.Guid());

        var fakeMovie = fakerMovie.Generate();
        var fakeScreeningRoom = fakerScreeningRoom.Generate();

        fakeScreeningRoom.AddMovie(fakeMovie);

        Should.Throw<InvalidOperationException>(() => fakeScreeningRoom.AddMovie(fakeMovie));
    }

    [Fact]
    public void Invalid_New_ScreeningRoom_Add_Movie_Not_Found()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    f.Lorem.Sentence().ClampLength(1, 50)
                )
            );

        var fakerMovie = new Faker<Movie>()
            .CustomInstantiator(f =>
                new Movie(
                    f.Lorem.Sentence().ClampLength(1, 50),
                    f.Name.FullName().ClampLength(1, 50),
                    f.Random.Int(0, 100)
                )
            )
            .RuleFor(m => m.Id, f => f.Random.Guid());

        var fakeMovie = fakerMovie.Generate();
        var fakeScreeningRoom = fakerScreeningRoom.Generate();

        fakeScreeningRoom.ShouldSatisfyAllConditions(
            () => fakeScreeningRoom.ContainsMovie(fakeMovie.Id).ShouldBeNull());
    }

    [Fact]
    public void Invalid_New_ScreeningRoom_Remove_Movie_Null()
    {
        var fakerScreeningRoom = new Faker<ScreeningRoom>()
            .CustomInstantiator(f =>
                new ScreeningRoom(
                    f.Random.Int(0, 100),
                    f.Lorem.Sentence().ClampLength(1, 50)
                )
            );

        var fakeScreeningRoom = fakerScreeningRoom.Generate();

        Should.Throw<ArgumentNullException>(() => fakeScreeningRoom.RemoveMovie(null!));
    }
}