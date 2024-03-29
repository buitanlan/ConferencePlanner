﻿using System.ComponentModel.DataAnnotations;

namespace GraphQL.Data;

public class Session
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]

    public string? Title { get; set; }
    [StringLength(4000)]

    public string? Abstract { get; set; }

    public DateTimeOffset? StartTime { get; set; }

    public DateTimeOffset? EndTime { get; set; }

    // Bonus points to those who can figure out why this is written this way
    public TimeSpan Duration =>
        EndTime?.Subtract(StartTime ?? EndTime ?? DateTimeOffset.MinValue) ??
        TimeSpan.Zero;

    public int? TrackId { get; set; }

    public ICollection<Speaker> Speakers { get; set; } =
        new List<Speaker>();

    public ICollection<Attendee> Attendees { get; set; } =
        new List<Attendee>();

    public Track? Track { get; set; }
}