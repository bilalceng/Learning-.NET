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

# 🚀 Backend Validation: Why It Matters

Frontend validation enhances user experience, but backend validation is **critical** for security, data integrity, and consistency. Attackers can easily bypass frontend checks using tools like Postman or by disabling JavaScript, making backend validation the **last line of defense** against malicious data.

## 🔥 Why Backend Validation is Essential

| Aspect            | Frontend Validation | Backend Validation |
|------------------|------------------|------------------|
| **Security**      | ❌ Can be bypassed | ✅ Protects against attacks |
| **Data Integrity**| ❌ Not enforced at the database level | ✅ Ensures accurate and valid data |
| **Consistency**   | ❌ Depends on individual clients | ✅ Applies to all API consumers |
| **Maintenance**   | ❌ Requires updates in multiple places | ✅ Single point of update |

### 🎯 Key Benefits:
✔ Ensures uniform rules for all API consumers (web, mobile, third-party integrations)  
✔ Prevents invalid or malicious data from reaching the database  
✔ Reduces maintenance overhead with centralized validation logic

💡 **In summary:** Frontend validation is a **convenience**, but backend validation is a **necessity** to protect your system and maintain reliable data processing.



### 🚀 Happy Coding!

