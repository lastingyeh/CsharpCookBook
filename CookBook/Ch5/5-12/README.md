### Implementing a Simple Performance Counter
```csharp
public static PerformanceCounter CreateSimpleCounter(string counterName,
    string counterHelp, PerformanceCounterType counterType, string categoryName, string categoryHelp)
{
    CounterCreationDataCollection counterCollection =
        new CounterCreationDataCollection();

    // Create the custom counter object and add it to the collection of counters
    CounterCreationData counter =
        new CounterCreationData(counterName, counterHelp, counterType);
    counterCollection.Add(counter);

    // Create category
    if (PerformanceCounterCategory.Exists(categoryName))
        PerformanceCounterCategory.Delete(categoryName);

    PerformanceCounterCategory appCategory =
        PerformanceCounterCategory.Create(categoryName, categoryHelp,
            PerformanceCounterCategoryType.SingleInstance, counterCollection);

    // Create the counter and initialize it
    PerformanceCounter appCounter =
        new PerformanceCounter(categoryName, counterName, false);

    appCounter.RawValue = 0;

    return (appCounter);
}
```

#### perform several actions on a PerformanceCounter object.
```csharp
long value = appCounter.Increment();
long value = appCounter.Decrement();
long value = appCounter.IncrementBy(i);
// Additionally, a negative number may be passed to the
// IncrementBy method to mimic a DecrementBy method
// (which is not included in this class). For example:
long value = appCounter.IncrementBy(-i);
```

####  take samples of the counter at various points in the application
```csharp
CounterSample counterSampleValue = appCounter.NextSample

// calculatedSample may be stored for future analysis.
float calculatedSample = CounterSample.Calculate(counterSampleValue,
    appCounter.NextSample());
```

