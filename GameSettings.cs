using System;
using System.IO;
using System.Media;
using System.Threading;

namespace Mathtopia
{
    /// <summary>
    /// Global settings shared across all forms.
    /// </summary>
    public static class GameSettings
    {
        public static int  Difficulty    = 3;   // 1 (easy) to 5 (hard)
        public static bool SpeechOutLoud = false;
        public static bool ColourChange  = false;
        public static int  Volume        = 50;  // 0-100
    }

    /// <summary>
    /// Centralised sound playback for Mathtopia.
    /// wav files must be placed in a "Sounds" subfolder of the project,
    /// with Build Action = Content and Copy to Output = PreserveNewest.
    /// Expected files: Correct.wav, Wrong.wav, Background.wav
    /// </summary>
    public static class SoundManager
    {
        private static Thread _bgThread;
        private static CancellationTokenSource _bgCts;

        // Look for wav files in a "Sounds" subfolder next to the exe
        private static string WavPath(string filename)
            => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds", filename);

        /// <summary>Play a one-shot sound effect. Volume 0 = silent.</summary>
        public static void PlayEffect(string filename)
        {
            if (GameSettings.Volume == 0) return;

            string path = WavPath(filename);
            if (!File.Exists(path)) return;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    using var player = new SoundPlayer(path);
                    player.PlaySync();
                }
                catch { /* swallow - audio is non-critical */ }
            });
        }

        /// <summary>Start looping Background.wav. Safe to call multiple times.</summary>
        public static void StartBackground()
        {
            StopBackground();

            string path = WavPath("Background.wav");
            if (!File.Exists(path)) return;

            _bgCts = new CancellationTokenSource();
            var token = _bgCts.Token;

            _bgThread = new Thread(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    if (GameSettings.Volume == 0)
                    {
                        Thread.Sleep(200);
                        continue;
                    }
                    try
                    {
                        using var player = new SoundPlayer(path);
                        player.PlaySync();
                    }
                    catch { break; }
                }
            })
            { IsBackground = true, Name = "BgMusicThread" };

            _bgThread.Start();
        }

        /// <summary>Stop the background music loop.</summary>
        public static void StopBackground()
        {
            try { _bgCts?.Cancel(); } catch { }
            _bgCts = null;
        }
    }
}
