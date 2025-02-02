using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.models;

public record struct SearchModel(
    int id,
    int page,
    [FromQuery(Name = "q")] string search,
    [FromHeader(Name = "sort")] bool? ascSort
    );