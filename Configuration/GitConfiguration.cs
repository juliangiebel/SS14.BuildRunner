﻿namespace SS14.BuildRunner.Configuration;

public sealed class GitConfiguration
{
    public const string Name = "Git";

    public string RepositoryUrl { get; set; } = string.Empty;

    public string Branch { get; set; } = "master";

    /// TODO: Move this into a separate configuration and back into SS14.MapServer for the next minor release
    /// <summary>
    /// If true the map server will retrieve the list of changed maps from the github diff api.
    /// If this is false all maps will get updated on every push.
    /// </summary>
    /// <remarks>
    /// Requires the map server to be installed as a github app.
    /// </remarks>
    public bool RetrieveMapFilesFromDiff { get; set; } = true;

    /// TODO: Move this into a separate configuration and back into SS14.MapServer for the next minor release
    /// <summary>
    /// Glob patterns for map files to check for
    /// </summary>
    public List<string> MapFilePatterns { get; set; } = ["Resources/Maps/*.yml"];

    /// TODO: Move this into a separate configuration and back into SS14.MapServer for the next minor release
    /// <summary>
    /// Glob patterns for excluding specific map files
    /// </summary>
    // ReSharper disable once CollectionNeverUpdated.Global
    public List<string> MapFileExcludePatterns { get; set; } = [];


    /// TODO: Move this into a separate configuration and back into SS14.MapServer for the next minor release
    /// <summary>
    /// Prevent updating maps when there where any c# files changed.
    /// </summary>
    /// <remarks>
    /// Requires the map server to be installed as a github app.
    /// This setting is recommended when the map server is configured to run for PRs
    /// as it prevents potentially malicious changes from being built and executed.
    /// </remarks>
    public bool DontRunWithCodeChanges { get; set; } = true;

    /// TODO: Move this into a separate configuration and back into SS14.MapServer for the next minor release
    /// <summary>
    /// Glob patterns used for detecting code changed
    /// </summary>
    public List<string> CodeChangePatterns { get; set; } = ["**/*.cs"];

    /// TODO: Move this into a separate configuration and back into SS14.MapServer for the next minor release
    /// <summary>
    /// Setting this to true enables listening to the PullRequest event for putting the rendered map as a comment into the PR
    /// </summary>
    public bool RunOnPullRequests { get; set; } = true;

    /// <summary>
    /// The identity git will use to pull changes with. This doesn't have an effect on anything but is required
    /// for pulling changes in some situations
    /// </summary>
    public GitIdentity Identity { get; set; } = new GitIdentity("ss14.mapserver", "git@mapserver.localhost");

    /// <summary>
    /// The ssh command used by git if set. Used for providing an ssh key to use.
    /// <example>"ssh -i [path to ssh key]"</example>
    /// </summary>
    public string? SshCommand { get; set; }

    public record GitIdentity(string Name, string Email);
}
