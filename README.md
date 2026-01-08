# Ejercicio 1: El imán inestable

## Concepto

El jugador controla una **esfera imantada** que se mueve por un escenario flotante. Algunos objetos metálicos reaccionan a su cercanía... pero **no siempre a su favor**.

## Mecánicas

- El jugador se mueve con **AddForce**.
- Cuando entre en un **Trigger** de un objeto metálico:
  - El objeto es atraído hacia el jugador.
- Si colisiona con demasiados objetos a la vez pierde el control o *explota*.

## Qué se practica

- AddForce para movimiento.
- OnTriggerEnter / Stay.
- Rigidbody.velocity para limitar o desestabilizar movimiento.
- Collision para penalizaciones.

## Variantes fáciles

- Imán que cambia de polaridad (atra/repele).
- Objetos con diferente *peso* (masa del Rigidbody).
- Zona que anula el magnetismo.

## Aprendizaje clave

Entender cómo fuerzas externas afectan a varios rigidbodies.

# Ejercicio 2: El suelo que miente

## Concepto

Un personaje debe cruzar una sala, pero **algunas plataformas son falsas**: solo se descubre cuando el jugador las *analiza*.

## Mecánicas

- El personaje se mueve con físicas.
- El suelo parece sólido, pero:
  - Al pisarlo, puede **caer**.
  - O desaparecer tras unos segundos.
- El jugador puede usar un **Raycast hacia abajo** para *examinar* el suelo.

## Qué se practica

- Raycast para detectar el suelo.
- Collision vs Trigger.
- Activar/desactivar colliders.
- Control de velocity al caer.

## Variantes fáciles

- Plataformas que solo aguantan cierto peso.
- Raycast que cambia el color del suelo al detectarlo.
- Plataformas que empujan al jugador con AddForce.

## Aprendizaje clave

Diferencia clara entre *detectar*, *colisionar* y *reaccionar*.
