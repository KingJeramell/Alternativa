# Agenda de Contactos Personales

Aplicación de escritorio desarrollada en **Windows Forms (C#)** para la gestión de contactos personales.  
Permite **registrar, listar y buscar contactos** de forma sencilla y organizada.

Hecho por Jeramell Feliz  
Matrícula: 2025-0047

## 📌 Funcionalidades

- Registrar contactos con los siguientes datos:
  - Nombre
  - Teléfono
  - Dirección
  - Instagram
  - Facebook
  - LinkedIn
- Listar todos los contactos registrados
- Buscar contactos por nombre o teléfono
- Visualización de datos mediante `DataGridView`
- Interfaz gráfica sencilla y profesional

---

## 🧱 Estructura del Proyecto

```text
AgendaContactos
│
├── Clases
│   └── Contacto.cs
│
├── Datos
│   └── ContactoDAO.cs
│
├── FrmContactos.cs
├── FrmContactos.Designer.cs
├── FrmContactos.resx
├── Program.cs
└── App.config
