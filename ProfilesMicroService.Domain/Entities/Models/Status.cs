﻿namespace ProfilesMicroService.Domain.Entities.Models;

public class Status
{
    public string Id { get; set; }
    public string Name { get; set; }

    public List<Doctor> Doctors { get; set; }
}