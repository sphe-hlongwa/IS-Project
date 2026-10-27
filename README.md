# TutAcadSupport

INFO2001A — Group 15: Stack Overflowed

A Windows Forms application using .NET Framework 4.7.2 and Microsoft Access.

## Open the project

1. Extract the entire ZIP into a new folder. Keep `Database` and `TutAcadApp` together inside `IS project`.
2. Open `TutAcadSupport.sln` in Visual Studio.
3. Keep the supplied **Debug | x86** solution configuration, then press **F5**. The project currently uses AnyCPU with Prefer32Bit disabled; the solution label does not force a 32-bit process.

The project requires the Visual Studio .NET desktop development workload, the .NET Framework 4.7.2 targeting pack and the 64-bit Microsoft Access database provider. Existing compatible installations can be used.

Build the source in Visual Studio to create the executable. Close one instance before opening another; both would use the same database.

There is no command-script launcher. All forms, their Designer files and resource files are included. In Solution Explorer, right-click a form's `.cs` file and choose **View Designer**.

## Accounts

| Role | Username | Password |
| --- | --- | --- |
| Administrator | admin | Admin123! |
| Student | 2000001 | Student123! |
| Student | 2000002 | Student123! |
| Tutor | tutor | Tutor123! |

These accounts and illustrative database records support the coursework demonstration. Students can register their own accounts. Administrators create tutor accounts. Passwords can be changed from Account → Change password.

## Contents

- `Database/TutAcadSupport.accdb`: the shared Access database.
- `Database/schema.sql`: database structure reference; the supplied database is already created.
- `TutAcadApp`: source code and Windows Forms.
- `Docs/User-guide.md`: navigation and workflows.
- `Docs/Interface-design.md`: application of Shneiderman's eight golden rules.

The application finds its database relative to `IS-project-root.txt`; keep this file in place. Changes are saved directly to the sibling Database folder. Back up the database before replacing or moving the project.
