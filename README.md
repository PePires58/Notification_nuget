Notification Service - Nuget

The goal of this nuget is share the notification service, the services available are:

* List notifications with our without filters
* Handle notification one by one or from a list
* Has notifications ?
* Any notifications (Func filter)

For more informations check the interface: INotificationService

To use, do not forget to register on IServiceCollections using the code bellow:

services.addScoped<INotificationService, NotificationService>();


If you are having any problems, open an issue.

Thanks a lot.

Pedro Henrique Pires
Escola de software (software school)