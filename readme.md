# Roll a Ball - Unity Project

## Descripción del Proyecto

Este proyecto es un juego simple de Unity llamado "Roll a Ball", donde el jugador controla una esfera que debe recolectar objetos en un escenario. El juego incluye mecánicas básicas de movimiento, recolección de objetos, y algunas interacciones adicionales como la capacidad de disparar objetos y cambiar entre cámaras.

## Características Principales

- **Control de Movimiento**: El jugador puede mover la esfera usando el teclado, un joystick virtual, o el acelerómetro del dispositivo móvil.
- **Recolección de Objetos**: El jugador debe recolectar objetos para avanzar en el juego. Al recolectar todos los objetos, se desbloquea una puerta y se muestra un mensaje de victoria.
- **Cambio de Cámara**: El jugador puede cambiar entre una cámara en primera persona y una cámara en tercera persona.
- **Disparo de Objetos**: El jugador puede disparar esferas en la dirección de la cámara principal.
- **Interacciones Especiales**: El jugador puede interactuar con objetos especiales como aceleradores, enemigos, y zonas de "Void" que teletransportan al jugador.

## Scripts Principales

### PlayerController.cs

Este script controla el movimiento del jugador, la recolección de objetos, el cambio de cámara, y el disparo de objetos. También maneja las interacciones con objetos especiales como aceleradores y enemigos.

### Rotator.cs

Este script hace que los objetos giren continuamente en el escenario.

### EnemyMovement.cs

Este script controla el movimiento de los enemigos, que siguen al jugador usando un NavMeshAgent.

### CameraController.cs

Este script controla la cámara en tercera persona, siguiendo al jugador desde una distancia fija.

### CameraController1st.cs

Este script controla la cámara en primera persona, permitiendo al jugador rotar la cámara usando el teclado o el tactil.

### Void.cs

Este script maneja la interacción con la zona de "Void", que teletransporta los objetos que entran en contacto con ella.

## Instrucciones de Uso

1. **Movimiento**: Usa las teclas W, A, S, D o las flechas direccionales para moverte. También puedes usar el joystick virtual en dispositivos móviles.
2. **Cambio de Cámara**: Presiona la tecla "C" para cambiar entre la cámara en primera persona y la cámara en tercera persona.
3. **Disparar**: Mantén presionada la tecla "Shift" para disparar esferas en la dirección de la cámara.
4. **Recolección de Objetos**: Colisiona con los objetos marcados como "PickUp" para recolectarlos. Al recolectar todos los objetos, se desbloquea una puerta y se muestra un mensaje de victoria.
5. **Interacciones Especiales**:
   - **Acelerador**: Colisiona con la rampa aceleradora para recibir un impulso hacia la derecha.
   - **Enemigo**: Si colisionas con un enemigo, serás teletransportado a la posicion inicial
   - **Void**: Si caes en la zona de "Void", serás teletransportado a la posicion inicial.

## Créditos

- **Desarrollador**: Marcos
- **Inspiración**: Damian

## Licencia

[WTFPL](LICENSE)