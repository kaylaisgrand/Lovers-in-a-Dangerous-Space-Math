using Fluent;

/// <summary>
/// Multilingual 
/// </summary>
public class Conversation13 : MyFluentDialogue
{
    private void SetLanguage(Language language)
    {
        LanguageManager.CurrentLanguage = language;
    }

    public override void OnFinish()
    {
        LanguageManager.CurrentLanguage = Language.English;
        base.OnFinish();
    }

    public override FluentNode Create()
    {
        return
            Show() *
            Write(0, speakManyLanguages) *
            Options
            (
                Option().Text(switchToEnglish).VisibleIf(() => LanguageManager.CurrentLanguage != Language.English) *
                    Do(() => SetLanguage(Language.English)) *

                Option().Text(switchToChinese).VisibleIf(() => LanguageManager.CurrentLanguage != Language.Mandarin) *
                    Do(() => SetLanguage(Language.Mandarin)) *

                Option().Text(switchToAfrikaans).VisibleIf(() => LanguageManager.CurrentLanguage != Language.Afrikaans) *
                    Do(() => SetLanguage(Language.Afrikaans)) *

                Option().Text(singMeASong) *
                    Write(singSong) *

                Option().Text(bye) *
                    Hide() *
                    Yell(bye) *
                    End()
            );
    }

    object[] singSong = {
                        Language.English, englishSong,
                        Language.Afrikaans, afrikaansSong,
                        Language.Mandarin, mandarinSong};
    object[] speakManyLanguages = {
                Language.English, "I speak a couple of languages",
                Language.Afrikaans, "Ek praat 'n paar tale",
                Language.Mandarin, "我讲几种语言"};
    object[] switchToEnglish = {
                Language.Mandarin, "改用普通话 (*)",
                Language.Afrikaans, "Skuif na Engels (*)"};
    object[] switchToChinese = {
                Language.English, "Switch to Mandarin",
                Language.Afrikaans, "Skuif na Shinees"};
    object[] switchToAfrikaans = {
                Language.English, "Switch to Afrikaans",
                Language.Mandarin, "切换到南非荷兰语"};
    object[] singMeASong = {
                Language.English, "Sing me a song!",
                Language.Afrikaans, "Sing vir my 'n liedjie!",
                Language.Mandarin, "唱歌"};
    object[] bye = {
                Language.English, "Bye",
                Language.Afrikaans, "Totsiens",
                Language.Mandarin, "再见"};


    const string afrikaansSong =
@"Wielie, Wielie, Waalie!
Die aap ry op sy baalie!
Tjoef tjaf val hy af
Wielie, Wielie, Waalie!";

    const string englishSong =
@"Ring-a-round the rosie,
A pocket full of posies,
Ashes! Ashes!
We all fall down!";

    const string mandarinSong =
@"我们 是 共产主义 接班人
继承 革命 先辈 的 光荣 传统
爱 祖国 爱 人民
鲜艳 的 红领巾 飘扬 在 前胸";
}
