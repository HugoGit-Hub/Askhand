using AskHand.Domain.Users.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace AskHand.Domain.Users;

public sealed class UserMetaData : ValueObject
{
    [MaxLength(25)]
    public string FirstName { get; }

    [MaxLength(25)]
    public string LastName { get; }

    [Range(0, 999)]
    public int Age { get; }

    public string PictureProfilPath { get; }

    public UserMetaData(string firstName, string lastName, int age, string pictureProfilPath)
    {
        if (string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(pictureProfilPath))
        {
            throw new UserMetaDataFormatException();
        }

        FirstName = firstName;
        LastName = lastName;
        Age = age;
        PictureProfilPath = pictureProfilPath;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
        yield return Age;
        yield return PictureProfilPath;
    }
}