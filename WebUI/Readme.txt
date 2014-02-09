Proyecto con funcionalidad base que sirva como punto de partida
Características:
- Compatibilidad (IE8+, Firefox, Chrome, Safari)
- Considerar escenarios de
  - Sitio para usuarios autenticados
  - Sitio para usuarios no autenticados
- Manejo de funcionalidad común
  - Despliegue de mensajes
    - Con callback
    - Sin callback
  - Menues
  - Tooltips
  - Ayudas
  - Selección de idioma y lenguaje
  - Datos requeridos
  - Datos válidos
    - Rangos (con independencia de configuración en el cliente)
    - Sintaxis (expresiones regulares - Ej. eMail, telef, etc)
    - Mascaras
  - Tipos de datos (capturas simplificadas9
    - Números (enteros, decimales, monetarios, positivos/negativos, listas)
    - Textos (alfabeticos, alfanumericos, con/sin espacios, libre)
    - Fechas
- Navegaciones Condicional
  - Tipos de Condicionales
    - OR AND [Default OR]



	
        <!--TEST COMPLETE-->
        <!--<navigate url="Tests_Condition/ConfirmCond1" condition="([MyProducts].Count>1)#AND#([MyEntity].Type == 'P')#AND#([[({SUM}[MyProducts].AmmountAvailable)]]>=100);"/>-->
        <!--TEST LIST OBJECT SUMMATORY-->
        <!--<navigate url="Tests_Condition/ConfirmCond1" condition="([[({SUM}[MyProducts].AmmountAvailable)]]>=100);"/>-->
        <!--TEST LIST OBJECT EVAL BOOLEAN-->
        <!--<navigate url="Tests_Condition/ConfirmCond1" condition="([MyFlag]==110)#AND#([MyProducts].Count>1)#AND#([MyProducts].Count>1)#AND#([[([MyProducts].Currency=='4')]]);"/>-->

Update-Package -Reinstall