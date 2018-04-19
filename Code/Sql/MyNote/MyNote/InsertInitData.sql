USE MyNote;

IF NOT EXISTS (SELECT * FROM NoteUser WHERE Account = '18827389685')
	INSERT INTO NoteUser(Name, Account, PhoneNumber, Email, ProfilePicture, HashCode, Salt, CreateTime, LastLoginTime, LastLoginAddress, Token, VerificationCode)
	VALUES('Cayden', '18827389685', '18827389685', '1406142870@qq.com', 'profilepictures/1/8d0003af-541c-4d86-8a4e-5437d79a964f.png','Nh506akEwfYnBhFzmIj7KkdQj6XjUcdsb5XhPMnBZz8=', '9d5de961-941e-4d4a-9371-5dd4360b6121', GETDATE(), GETDATE(), '192.168.2.32','8d0003af-541c-4d86-8a4e-5437d79a964f', '');