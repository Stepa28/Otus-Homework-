using PleasingTheNumber.Clases;
using PleasingTheNumber.Interface;

IPlayable play = new Play(
    new IOConsole(new OutputConsole(), new InputConsole())
    , new Rnd()
    , new ValidateInt()
    , new Compare()
    , new IntConverter()
    );

play.Init();
play.Gamble();