﻿using System;
using System.Collections.Generic;
using System.Reactive.Threading.Tasks;
using Octokit;
using Octokit.Models.Request.Enterprise;
using Octokit.Reactive;

/// <summary>
/// A client for managing licenses for GitHub Copilot for Business
/// </summary>
public class ObservableCopilotLicenseClient : IObservableCopilotLicenseClient
{
    private readonly ICopilotLicenseClient _client;

    public ObservableCopilotLicenseClient(IGitHubClient client)
    {
        _client = client.Copilot.License;
    }
    
    /// <summary>
    /// Removes a license for a user
    /// </summary>
    /// <param name="organization">The organization name</param>
    /// <param name="userName">The github users profile name to remove a license from</param>
    /// <returns>A <see cref="CopilotSeatAllocation"/> instance with results</returns>
    public IObservable<CopilotSeatAllocation> Remove(string organization, string userName)
    {
        Ensure.ArgumentNotNull(organization, nameof(organization));
        Ensure.ArgumentNotNull(userName, nameof(userName));

        return _client.Remove(organization, userName).ToObservable();
    }

    /// <summary>
    /// Removes a license for one or many users
    /// </summary>
    /// <param name="organization">The organization name</param>
    /// <param name="userSeatAllocation">A <see cref="UserSeatAllocation"/> instance, containing the names of the user(s) to remove licenses for</param>
    /// <returns>A <see cref="CopilotSeatAllocation"/> instance with results</returns>
    public IObservable<CopilotSeatAllocation> Remove(string organization, UserSeatAllocation userSeatAllocation)
    {
        Ensure.ArgumentNotNull(organization, nameof(organization));
        Ensure.ArgumentNotNull(userSeatAllocation, nameof(userSeatAllocation));
        
        return _client.Remove(organization, userSeatAllocation).ToObservable();
    }

    /// <summary>
    /// Assigns a license to a user
    /// </summary>
    /// <param name="organization">The organization name</param>
    /// <param name="userName">The github users profile name to add a license to</param>
    /// <returns>A <see cref="CopilotSeatAllocation"/> instance with results</returns>
    public IObservable<CopilotSeatAllocation> Assign(string organization, string userName)
    {
        Ensure.ArgumentNotNull(organization, nameof(organization));
        Ensure.ArgumentNotNull(userName, nameof(userName));
        
        return _client.Assign(organization, userName).ToObservable();
    }
    
    /// <summary>
    /// Assigns a license for one or many users
    /// </summary>
    /// <param name="organization">The organization name</param>
    /// <param name="userSeatAllocation">A <see cref="UserSeatAllocation"/> instance, containing the names of the user(s) to add licenses to</param>
    /// <returns>A <see cref="CopilotSeatAllocation"/> instance with results</returns>
    public IObservable<CopilotSeatAllocation> Assign(string organization, UserSeatAllocation userSeatAllocation)
    {
        Ensure.ArgumentNotNull(organization, nameof(organization));
        Ensure.ArgumentNotNull(userSeatAllocation, nameof(userSeatAllocation));
        
        return _client.Assign(organization, userSeatAllocation).ToObservable();
    }

    /// <summary>
    /// Gets all of the currently allocated licenses for an organization
    /// </summary>
    /// <param name="organization">The organization</param>
    /// <param name="copilotApiOptions">Options to control page size when making API requests</param>
    /// <returns>A list of <see cref="CopilotSeats"/> instance containing the currently allocated user licenses.</returns>
    public IObservable<IReadOnlyList<CopilotSeats>> GetAll(string organization, ApiOptions copilotApiOptions)
    {
        Ensure.ArgumentNotNull(organization, nameof(organization));
        Ensure.ArgumentNotNull(copilotApiOptions, nameof(copilotApiOptions));
        
        return _client.GetAll(organization, copilotApiOptions).ToObservable();
    }
}
