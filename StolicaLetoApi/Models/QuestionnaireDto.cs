using System;
using System.Collections;
using System.Collections.Generic;

namespace StolicaLetoApi.Models;

public partial class QuestionnaireDto
{
    public int Id { get; set; }

    public int? Smena { get; set; }

    public BitArray[]? Qimage { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Sex { get; set; }

    public string? WorkingPlace { get; set; }

    public string? Post { get; set; }

    public string? PhoneNumber { get; set; }

    public string? TelegramUsername { get; set; }

    public string? ClothesSize { get; set; }

    public string? Allergies { get; set; }

    public string? Illneses { get; set; }

    public string? KnowledgeSource { get; set; }

    public string? DesiredSkills { get; set; }

    public string? ExpirienceIntentions { get; set; }

    public BitArray[]? Qvideo { get; set; }

    public string? FatherName { get; set; }

    public string? VkLink { get; set; }
}
