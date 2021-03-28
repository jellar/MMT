using System;
using AutoMapper;

namespace MMT.Application.Profiles
{
    public class DateTimeToStringFormatter : ITypeConverter<DateTime?, string>
    {
        public string Convert(DateTime? source, string destination, ResolutionContext context)
        {
            return source ==
                   null ? String.Empty : source?.ToString("dd-MMM-yyyy");

        }
    }
}