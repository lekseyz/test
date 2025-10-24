﻿namespace test.UseCases.Contributors.Update;

public record UpdateContributorCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
