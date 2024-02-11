using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public class clsSoundEffect
{
    static  SoundPlayer SoundEffect;
    public static void _PlayEndSoundEffect(bool Won)
    {
        if (Won)
        {
            SoundEffect = new SoundPlayer(@"C:\Users\omerm\Downloads\tone\win.wav");
            SoundEffect.Play();
            Thread.Sleep(2000);
            SoundEffect.Stop();
        }
        else
        {
            SoundEffect = new SoundPlayer(@"C:\Users\omerm\Downloads\tone\lose.wav");
            SoundEffect.Play();
            Thread.Sleep(2000);
            SoundEffect.Stop();
        }
    }
}

