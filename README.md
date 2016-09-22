RxUI6WithAutofac
================

Sample usage of Autofac with ReactiveUI 6

This project uses the [ReactiveUI.Autofac](https://github.com/alexeyzimarev/ReactiveUI.Autofac) library (nuget package) for the resolver adapter and registrations of all required components.

The original project is @jen20 reactive-routing sample https://github.com/jen20/reactive-routing

Since RxUI only uses the Service Locator pattern, this usage of Autofac IoC could be arguable. However, if you need to have complex dependencies to be injected in your views or models, using a container that you got used to, could be handy. Otherwise, don't bother and use the default RxUI locator - Splat ModernDependencyResolver.
