# User guide

## Navigation

Sign in with the account for your role. The navigation bar stays at the top of the main window. Home returns to the dashboard; Back returns to the previous page. Account contains Change password and Sign out. Page entries remain available while navigating until you sign out. Sign-out asks for confirmation before discarding unsaved entries.

Use Tab and Shift+Tab to move through fields. Alt+Left goes back, Ctrl+Home opens Home, and F5 refreshes the current list where a Refresh button is available. Resize or maximise the window as needed. Long pages scroll vertically; long lists have their own scrollbars. An asterisk marks a required field.

## Students

Registration requires an age of 17 or older. Tick the date-of-birth field and enter your actual birth date; dates later than the eligibility cutoff cannot be selected. The service also enforces the age rule before saving. Existing accounts are not deleted or changed. Enter a 7–10 digit student number, your names, a valid email or a phone number with 10–15 digits, your faculty/programme and a nonblank password of 8–128 characters.

Open My bookings. Choose a course, support type and future start/end time on the same day. Find available tutors, choose one and select Book session. Changing the course or dates clears the previous availability search. Availability is checked again before saving.

In Manage your bookings, select a row. Separate edit fields display that booking's dates. Scheduled bookings can be changed or cancelled at least 48 hours before their original start. Cancellation asks for confirmation. Completed sessions can receive a feedback rating from 0 to 10. Buttons reflect the selected booking's permitted actions.

When no tutor is available, enter your availability under Request support and submit a request using the chosen course and support type. An administrator can match it later. Refresh updates both lists.

## Administrators

Tutors: enter a profile and a new account username/password, then Save tutor. Select an existing tutor to edit their profile. Discard edits reloads the saved profile. Add another tutor clears the editor for a new profile. Assign qualified courses and open the selected tutor's availability page.

Support requests: select a Submitted request, choose dates and find suitable tutors. Select an available tutor and choose Verify and book. Changing the request or dates requires a new search. The service checks qualifications, availability and timetable clashes before committing a booking.

Attendance: select an ended session whose status is Scheduled. Choose Completed or Absent, enter session notes and save. Students supply their own feedback separately.

Reports: choose one of the three programme reports and Generate report. Outstanding requests uses calendar age of at least seven days and does not require a period. Workload and performance reports use the inclusive date range selected. Print preview, Print / PDF and Export CSV become available after generation. Changing criteria requires regeneration. Saving a PDF uses a PDF printer installed on Windows.

## Tutors

Availability: add future periods within one day. Select an existing period to edit or remove it. Removing a period asks for confirmation. Existing bookings are protected when changing availability.

Attendance: record attendance and notes for your ended scheduled sessions.

## Messages and persistence

Successful changes display a confirmation. Invalid entries produce a message and leave the form open for correction. Bookings, tutor qualifications, availability and authentication checks are enforced in the service layer as well as the interface. Database failures are logged to `application-errors.log` if the project directory is writable.

The supplied availability covers 24 October to 22 November 2026. An administrator or tutor can add further dates through Availability. Existing historical sessions and requests support the reporting workflows.
