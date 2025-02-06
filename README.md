# Data Annotations in .NET Minimal API

## Overview
Data annotations in .NET Minimal API provide a simple way to validate incoming requests using attributes. These annotations ensure that request models meet specified validation rules before processing.

---

## Common Data Annotations
| Attribute           | Description |
|--------------------|-------------|
| `[Required]`       | Ensures the property is not null or empty. |
| `[MaxLength(n)]`   | Limits the maximum length of a string property. |
| `[MinLength(n)]`   | Enforces a minimum length for a string property. |
| `[StringLength(n)]` | Specifies both minimum and maximum length. |
| `[Range(min, max)]` | Ensures a number falls within a specified range. |
| `[EmailAddress]`   | Validates email format. |
| `[Phone]`          | Validates phone number format. |
| `[Url]`            | Ensures the property is a valid URL. |
| `[RegularExpression(pattern)]` | Validates using a custom regex pattern. |

---

## Example: Using Data Annotations in a Minimal API

### 1. Define a Request Model
```csharp
public class UserRequest
{
    [Required]
    [MinLength(3)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Range(18, 99)]
    public int Age { get; set; }
}
```

### 2. Validate Data in a Minimal API Endpoint
```csharp
app.MapPost("/register", (UserRequest request) =>
{
    var validationContext = new ValidationContext(request);
    var validationResults = new List<ValidationResult>();
    
    if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
    {
        return Results.BadRequest(validationResults);
    }
    
    return Results.Ok("User registered successfully!");
});
```

---

## Additional Notes
- Use `FluentValidation` for more advanced validation scenarios.
- Custom validation attributes can be created by inheriting from `ValidationAttribute`.
- Model validation automatically works when using `[ApiController]` in traditional controllers but needs manual handling in Minimal APIs.

---

### 🚀 Happy Coding!

