USE MyNote;
SELECT TOP 100 * FROM Note;
--EXEC Sp_Add_NoteBrowsedRecord 1, 1;
EXEC Sp_Select_NoteById 1;
--SELECT TOP 100 * FROM NoteBrowsedRecord;
EXEC Sp_Select_NoteSearchByRemark 10, 1, 'C#';