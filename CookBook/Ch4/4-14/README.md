### Speeding Up LINQ Operations with Parallelism

#### To process the collection of RecipeChapters (chapters in the example) with regular LINQ
```csharp
chapters.Select(c => TimedEvaluateChapter(c, rnd)).ToList();

// AsParallel extension method
chapters.AsParallel().Select(c => TimedEvaluateChapter(c, rnd)).ToList();

```

#### 