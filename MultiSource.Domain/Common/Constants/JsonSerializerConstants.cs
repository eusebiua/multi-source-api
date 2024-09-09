using System.Text.Json;

namespace MultiSource.Domain.Common.Serialzers;

public static class JsonSerializerConstants
{
    public static readonly JsonSerializerOptions PropertyNameCaseInsensitive = new() { PropertyNameCaseInsensitive = true };
}
