# WebApiValidCustom
 Asp Net Custom Validations with WebApi


#Exemplo De Validação Customizada 
[EmailInUse]
[BlockDomain("gmail.com")] 


public class CreateUserModel
{
    [Required(ErrorMessage ="O usuário é obrigatório")]
    [StringLength(20,MinimumLength =3,
        ErrorMessage ="O nome do usuário deve conter entre 3 e 10 caracteres!")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage ="Email inválido!")]
    [EmailInUse]
    [BlockDomain("gmail.com")]  //bloquear emails do gmail
    public string? Email { get; set; }
    [Required(ErrorMessage = "Senha é obrigatório")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Salário é obrigatório")]
    [Range(0,999.99,ErrorMessage ="Você ganha muito!")]
    public decimal Salary { get; set; }
}

public class EmailInUseAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return (string?)value == "master@gmail.com"
            ? new ValidationResult(errorMessage:"Este e-mail já está em uso")
            : ValidationResult.Success;
    }
}

public class BlockDomainAttribute : ValidationAttribute
{
    public string Domain { get; set; }

    public BlockDomainAttribute(string domain)
    {
        Domain = domain;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        string v = value as string ?? string.Empty;
        return v.Contains(Domain)
            ? new ValidationResult(errorMessage: "Domínio inválido")
            : ValidationResult.Success;
    }
}
