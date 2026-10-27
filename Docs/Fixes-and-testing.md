# Validation and workflow fixes — 26 October 2026

## Changes

- New student registration requires age 17 or above, including the exact 17th birthday. This is checked before database writes, as well as through the date picker's maximum date.
- The birth date starts unchecked: users must select it rather than silently accepting a hard-coded 2005 birth date. The existing earliest supported birth date, 1 January 1900, is retained.
- Student numbers must be 7–10 ASCII digits. The registration textbox is limited to 10 characters.
- Student/tutor names reject numeric-only and punctuation-only input while accepting Unicode letters, spaces, apostrophes, hyphens and full stops.
- Phone validation counts actual digits (10–15), instead of allowing ten dashes/spaces. Email validation rejects display-name text and missing domain suffixes.
- New/changed passwords cannot consist entirely of whitespace. Existing password hashes and the login verification algorithm are unchanged.
- Empty login entries and a missing password-change account now have explicit validation. Unrecognised stored account roles are rejected.
- Student/tutor/account/qualification inserts name their columns explicitly, avoiding dependence on Access table column order.
- Course qualification checks validate the selected tutor and course before inserting.
- Starting a tutor search clears its previous results, including when the new search fails.
- The request screen enables tutor search only for selected Submitted requests.
- Grid actions require an explicitly selected row.
- Availability pages use tutor IDs in their navigation keys, so two tutors with identical names cannot open the same cached page.
- Report printing prevents oversized rows from endlessly producing another page; an oversized row is limited to the printable page area. Export CSV preserves full values. Very small paper sizes receive an explanatory error.
- README build instructions now match the supplied solution, and no longer claim that a compiled executable is included.

## Preserved

The Access database is byte-for-byte identical to the attachment: no accounts, passwords, records or schema were changed. The solution, project configuration, database connection/provider detection and current parameterless transaction calls were retained. Historical isolation-level exceptions in the supplied log are not evidence of a new failure in this version; the supplied source already uses the parameterless calls.

No database reset or migration is required. The same Windows Forms design, role permissions, password hashing, overlap prevention, feedback range, attendance timing and 48-hour cancellation rule remain.

## Checks completed here

- All 32 C# source files (including the test source) parsed without syntax errors.
- All project compile/resource references resolve; all form resource XML parses.
- Database, schema, solution, project build configuration and Db.cs compared byte-for-byte with the supplied archive.
- Registration's age validation confirmed before hashing and database writes.

This is source/syntax validation, not a successful build or a Windows runtime test. This Linux environment has no Windows Forms/ACE installation or C# compiler available. The full Visual Studio build, Access operations, rendering and printing must still be checked on Windows. It is not possible to guarantee that every defect is eliminated without those checks.

## Automated rule tests on Windows

Run `Tests\Run-tests.cmd` from Command Prompt. It compiles and runs RulesTests.cs against the actual Rules.cs without connecting to or changing the database. Tests cover the 17-year age boundary, future/invalid birth dates, leap-day handling, names, contacts, password hashing, session periods, overlaps and the exact 48-hour boundary. These executable tests are included but were not run in this environment.

Leap-day policy: the cutoff is today's date minus 17 calendar years. A 29 February birth date becomes eligible on 1 March in a non-leap eligibility year.

## Windows smoke test

1. Close the current application. Extract this ZIP into a separate folder, preserving your previous working copy. Open TutAcadSupport.sln, keep the supplied configuration, and rebuild in Visual Studio.
2. Sign in with an existing administrator, tutor and student account. Verify that each role retains its existing screens.
3. Register with birth date unchecked: reject. Confirm a one-year-old or 16-year-old date cannot be selected; the service test rejects them too. Register a new, unique student number with the exact 17-year cutoff date: accept. Sign in with the new account.
4. Try invalid names, a phone made only of dashes, malformed email, mismatched passwords and a duplicate student number. Each must reject without partial account creation.
5. Add a tutor, assign a course, add future availability, and book a session. Verify overlapping student/tutor sessions are refused. Match a Submitted request and confirm it becomes Scheduled.
6. Confirm changes/cancellations work at least 48 hours before start and are refused below that limit. Mark an ended session and rate it as its student.
7. Open availability for two tutors who share a name and verify each page shows the correct ID.
8. Generate, preview and export reports. Test the chosen printer/paper size and check pagination.

The included database is the snapshot you uploaded. If your live database has changed since upload, back it up and retain that newer database when applying the source changes; do not overwrite newer records with this snapshot.
