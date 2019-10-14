# duEco

La arquitectura utilizada es:
* View
* ViewModel
* Model
* Servicio

View -> Son las interfaces con los controles UI. Consta de 2 archivos: .xaml y .xaml.cs

ViewModel -> Capa intermedia entre View y Model. Se declara con herencia del Model con las llamadas a los metodos declarados y que necesite llamar de el Servicio 

Model -> representa el modelo la Entidad en nuestra BD

Servicio -> Guarda el comportamiento del negocio
