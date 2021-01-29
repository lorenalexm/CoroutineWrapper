# Unity Coroutine Wrapper
This project attempts to wrap the [coroutine](https://docs.unity3d.com/ScriptReference/Coroutine.html) system that is used by [Unity](https://unity.com). In wrapping these components within a class, it should allow for use within Unity under a [Swift](https://swift.org) coding environment.

## Usage
Usage of this library should follow Unity standards for starting a coroutine.

```csharp
// C#
private void Start()
{
    StartCoroutine(CoroutineWrapper.WaitForSeconds(1f, () => { Debug.Log("Inside a coroutine!"); }))
}
```

```swift
// Swift
private func Start() {
    StartCoroutine(CoroutineWrapper.WaitForSeconds(0.5) {
        Debug.Log("Inside a coroutine!")
    })
}
```

## Gotchas
This [Visual Studio](https://visualstudio.microsoft.com) project directly references a Unity library. This library is from Unity 2019.4.8f1. There may, or may not be, issues if attempting to use this wrapper with a different version of Unity.