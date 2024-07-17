using PleasingTheNumber.Clases;

var paly = new Play(
    new IOConsole(new OutputConsole(), new InputConsole())
    , new Rnd()
    , new ValidateInt()
    , new Compare()
    , new IntConverter()
    );
paly.Init();
paly.Gamble();