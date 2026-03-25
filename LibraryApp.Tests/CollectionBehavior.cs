using Xunit;

// Disable parallel execution of tests (prevents shared state issues)
[assembly: CollectionBehavior(DisableTestParallelization = true)]