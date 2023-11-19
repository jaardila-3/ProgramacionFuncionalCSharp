# Language Integrated Query
* LINQ aparece en el año 2007 con el namespace System.Linq, es un conjunto de tecnologías que permiten la integración de capacidades de consulta directamente con los lenguajes de programación soportados por .NET y que permite trabajar con colecciones.
* Tiene dos formas de uso:
1. Query Expressions (sintaxis expresiones de consulta): consulta muy parecida a SQL pero con sintaxis C#
2. Extension Methods (sintaxis métodos de extensión): son métodos que aparecen dentro de una colección y me permiten hacer filtros y diferentes transformaciones con funciones de Linq.
* Estos métodos están incluidos dentro de Name space System.linq, viene por defecto en .Net a partir de la versión 5

* NOTA: Las expresiones de LINQ suelen devolver un IEnumerable, que es una interfaz que define un enumerador, que permite iterar sobre una colección. Sin embargo, hay casos en los que necesitamos trabajar con una lista, por lo que es necesario convertir el resultado de la expresión LINQ en una lista utilizando el método ToList(). De esta manera, podemos trabajar con la lista resultante como cualquier otra lista de C# 