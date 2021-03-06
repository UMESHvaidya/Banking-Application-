
CREATE PROCEDURE MINI_STATEMENT
@ACCNO INT
AS
	BEGIN
	SELECT *, GETDATE() FROM CUST_TRANSACTION WHERE ACCNO=@ACCNO	
	END
GO



CREATE PROCEDURE BALANCE_ENQ
@ACCNO INT
AS 
BEGIN
SELECT BALANCE FROM CUST_TRANSACTION WHERE ACCNO = @ACCNO;
END
GO






CREATE PROCEDURE DEPOSIT
@ACCNO INT,
@AMOUNT FLOAT
AS
	BEGIN
	IF EXISTS(SELECT ACCNO FROM CUSTOMER_REGISTRATION WHERE ACCNO = @ACCNO)
UPDATE CUSTOMER_REGISTRATION
SET BALANCE = BALANCE+@AMOUNT WHERE ACCNO=@ACCNO
END
GO

EXEC DEPOSIT 100000000,500

SELECT * FROM CUSTOMER_REGISTRATION



CREATE PROCEDURE WITHDRAW
@ACCNO INT,
@AMOUNT FLOAT
AS
	BEGIN
	IF EXISTS(SELECT ACCNO FROM CUSTOMER_REGISTRATION WHERE ACCNO = @ACCNO)
UPDATE CUSTOMER_REGISTRATION
SET BALANCE = BALANCE-@AMOUNT WHERE ACCNO=@ACCNO
END
GO
