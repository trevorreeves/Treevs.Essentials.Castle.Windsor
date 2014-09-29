treeves.essentials.castle.windsor
=================================

Little additions to CastleWindsor that I wouldn't ever leave the house without.

### DependsOnFacility

```
    // if container doesn't currently have the supplied facility, add it.
    container.DependsOnFacility<TypedFactoryFacility>();

    // if container doesn't currently have the supplied facility, add it, and do something once that's done.
    container.DependsOnFacility<TypedFactoryFacility>((facilityAdded) => { /* do stuff */ } );
```

### HasFacility

```
    // does the container already have the supplied facility installed
    container.HasFacility<TypedFactoryFacility>();
```
    
### ReleasingWrapper

```
using (var myCompWrapper = ReleasingWrapper.Create(myCompFactory.Create(), myCompFactory.Release))
{
  // do stuff with myCompWrapper.WrappedObject
}
```


Also I have a useful cheat sheet here with the common things I tend to need:
https://docs.google.com/document/d/1dVBHQv835s-KkdamDAc_ZS3HhLAw8UwfDsgA7zvZq-4/edit?usp=sharing
