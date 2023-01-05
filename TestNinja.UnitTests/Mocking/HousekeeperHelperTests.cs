namespace TestNinja.UnitTests.Mocking;

public class HousekeeperHelperTests
{
    private Mock<IHousekeeperRepository> _housekeeperRepository;
    private Mock<IStatementHelper> _statementHelper;
    private Mock<IEmailHelper> _emailHelper;
    private Mock<IXtraMessageBox> _xtraMessageBox;
    private HousekeeperHelper _housekeeperHelper;
    private Housekeeper _housekeeper;
    private DateTime _statementDate;
    private string _statementFilename;

    [SetUp]
    public void SetUp()
    {
        _statementFilename = "test file name";
        _statementDate = DateTime.Parse("2023-01-05");
        _housekeeper = new Housekeeper
        {
            Email = "test email",
            Oid = 1,
            FullName = "test name",
            StatementEmailBody = "test email content"
        };

        _housekeeperRepository = new Mock<IHousekeeperRepository>();
        _housekeeperRepository.Setup(x => x.GetQueryableHouseKeepers())
            .Returns(new List<Housekeeper> {
                _housekeeper,
            }.AsQueryable());

        _statementHelper = new Mock<IStatementHelper>();
        _statementHelper
            .Setup(x => x.Save(_housekeeper.Oid, _housekeeper.FullName, _statementDate))
            .Returns(() => _statementFilename);
        
        _emailHelper = new Mock<IEmailHelper>();
        _xtraMessageBox = new Mock<IXtraMessageBox>();
        _housekeeperHelper = new HousekeeperHelper(
            _housekeeperRepository.Object,
            _statementHelper.Object,
            _emailHelper.Object,
            _xtraMessageBox.Object
        );
    }
    
    [Test]
    public void SendStatementEmails_WhenCalled_SaveStatement()
    {
        // act
        _housekeeperHelper.SendStatementEmails(_statementDate);

        // assert
        _statementHelper.Verify(x => 
            x.Save(_housekeeper.Oid, _housekeeper.FullName, _statementDate));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void SendStatementEmails_WhenEmailIsInvalid_NotSaveStatement(string email)
    {
        // arrange
        _housekeeper.Email = email;

        // act
        _housekeeperHelper.SendStatementEmails(_statementDate);

        // assert
        _statementHelper.Verify(x => 
            x.Save(_housekeeper.Oid, _housekeeper.FullName, _statementDate), 
            Times.Never);
    }

    [Test]
    public void SendStatementEmails_ValidStatementFilename_SendEmail()
    {
        // act
        _housekeeperHelper.SendStatementEmails(_statementDate);

        // assert
        VerifyEmailIsSent();
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void SendStatementEmails_InvalidStatementFilename_NotSendEmail(string statementFilename)
    {
        // arrange
        _statementFilename = statementFilename;

        // act
        _housekeeperHelper.SendStatementEmails(_statementDate);

        // assert
        VerifyEmailIsNotSent();
    }

    [Test]
    public void SendStatementEmails_EmailFail_ShowMessage()
    {
        // arrange
        _emailHelper
            .Setup(x => x.Email(
                _housekeeper.Email, 
                _housekeeper.StatementEmailBody, 
                _statementFilename,
                It.IsAny<String>()))
            .Throws<Exception>();

        // act
        _housekeeperHelper.SendStatementEmails(_statementDate);

        // assert
        _xtraMessageBox.Verify(x => x.Show(
            It.IsAny<string>(),
            It.IsAny<string>(),
            MessageBoxButtons.OK
        ));
    }

    private void VerifyEmailIsSent()
    {
        _emailHelper.Verify(x => x.Email(
            _housekeeper.Email, 
            _housekeeper.StatementEmailBody, 
            _statementFilename,
            It.IsAny<String>())
        );
    }

    private void VerifyEmailIsNotSent()
    {
        _emailHelper.Verify(
            x => x.Email(
                It.IsAny<String>(), 
                It.IsAny<String>(), 
                It.IsAny<String>(),
                It.IsAny<String>()),
            Times.Never);
    }
}