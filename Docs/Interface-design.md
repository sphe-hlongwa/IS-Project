# Interface design: Shneiderman's eight golden rules

| Rule | Implementation |
| --- | --- |
| Strive for consistency | Shared page layout, navigation, typography, action buttons, date formats and readable grid headings. |
| Seek universal usability | Keyboard navigation, named controls, shortcuts, wrapping field groups, DPI scaling and scrollable pages. |
| Offer informative feedback | Availability search results, selected-booking context, status messages and clear success/error dialogs. |
| Design dialogs to yield closure | Booking, profile, availability, attendance and export actions report completion; lists refresh after a successful change. |
| Prevent errors | Required-field and format validation, constrained choices, disabled unavailable actions, invalidated stale searches and service checks for booking conflicts. |
| Permit easy reversal of actions | Discard tutor edits, cancel account/password entry, return through Back/Home, edit permitted bookings and confirm destructive actions. Cancellation is a recorded status change; restoring a cancelled booking requires a new booking and availability check. |
| Keep users in control | Persistent Home/Back navigation, role-specific pages and an explicit sign-out confirmation. Opening a feature uses the main window rather than stacking modal feature windows. |
| Reduce short-term memory load | Visible field labels, selected booking details, separate new-booking/edit fields, retained page entries and context beside actions. |

The 48-hour restriction, authorization and data integrity rules take precedence over unrestricted undo. Database transactions protect multi-step writes. This design supports the principles without claiming that every action is reversible.

Reference: Ben Shneiderman, The Eight Golden Rules of Interface Design, University of Maryland: https://www.cs.umd.edu/users/ben/goldenrules.html

## Visual theme

The look and layout of every form are stored in its `.Designer.cs` file, so the Visual Studio designer shows the same design as the running app. Colours and fonts follow one palette: midnight ink and navy (menu, headings, primary buttons), champagne gold accent (rules, hover, active page), warm ivory page canvas and tinted panels. Headings use Georgia; body text uses Segoe UI. Fields sit in a two-column grid with the label above a full-width input, and the action buttons sit in a right-hand column on single-panel pages.

`TutAcadApp/Services/Ui.cs` holds the palette (`Theme`), the custom controls (`BrandPanel`, `TileButton`, `SoftBorderPanel`) and behaviour only (`Ui.Behave`: tooltips, disabled-button styling, table styling, resize handling). Put your team logo at `Assets/logo.png` (and an ivory-on-transparent version at `Assets/logo-dark.png` for dark backgrounds).
