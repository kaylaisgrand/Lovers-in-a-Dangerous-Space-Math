using Fluent;

public class Conversation2 : MyFluentDialogue
{
    public override FluentNode Create()
    {
        return
            Yell("I love ...") *
            Yell("CAKE!") *
            Yell("And chained responses!");
    }
}
