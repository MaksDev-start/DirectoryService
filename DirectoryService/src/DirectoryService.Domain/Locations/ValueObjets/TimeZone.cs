using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Constants;

namespace DirectoryService.Domain.Locations.ValueObjets;

public sealed record TimeZone
{
    
    private const string IANA_TIME_ZONE_REGEX = @"^(?:[A-Za-z_]+/)?[A-Za-z_]+(?:/[A-Za-z_]+)*$";
    
    private TimeZone(string value)
    {
        Value = value;
    }

    public string Value { get; }
    
    public static Result<TimeZone> Create(string timeZone)
    {
        return Result.Success(timeZone)
            .Ensure(
                tz => !string.IsNullOrWhiteSpace(tz), 
                "Time zone cannot be empty.")
            .Ensure(
                tz => tz.Length is >= LengthConstants.MINLENGTH3 
                    and <= LengthConstants.MAXLENGTH50, 
                "Time zone must be 2-50 characters.")
            .Ensure(
                tz => Regex.IsMatch(timeZone, IANA_TIME_ZONE_REGEX), 
                "Invalid IANA format. Use format: 'Continent/City' like 'America/New_York'.")
            .Map(tz => new TimeZone(tz));
    }
}