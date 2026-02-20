using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;
using DirectoryService.Shared;

namespace DirectoryService.Domain.Locations.ValueObjects;

public sealed record TimeZone
{
    private const string IANA_TIME_ZONE_REGEX = @"^[A-Za-z_]+/[A-Za-z_]+$";

    private TimeZone(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<TimeZone, Error> Create(string timeZone)
    {
        return Result.Success<string, Error>(timeZone)
            .Ensure(
                tz => !string.IsNullOrWhiteSpace(tz),
                GeneralErrors.ValueIsInvalid(
                    "Time zone cannot be empty."))
            .Ensure(
                tz => tz.Length is >= LengthConstants.MINLENGTH3
                    and <= LengthConstants.MAXLENGTH50,
                GeneralErrors.ValueIsInvalid(
                    "Time zone must be 2-50 characters."))
            .Ensure(
                tz => Regex.IsMatch(timeZone, IANA_TIME_ZONE_REGEX),
                GeneralErrors.ValueIsInvalid(
                    "Invalid IANA format. Use format: 'Continent/City' like 'America/New_York'."))
            .Map(tz => new TimeZone(tz));
    }
}