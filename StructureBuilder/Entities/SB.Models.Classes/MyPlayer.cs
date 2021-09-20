/*
 * MIT License
 * 
 * Copyright (c) 2021 [FacuFalcone]
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using SBExceptions;
using WMPLib;

namespace Models {

    public delegate void SoundPlayerHandler(object songName);

    public sealed class MyPlayer {

        #region Attributes

        public event SoundPlayerHandler ESoundPlayer;
        private readonly WindowsMediaPlayer player;
        private const string FORMAT = ".mp3";

        #endregion

        #region Builders

        /// <summary>
        /// Creates the entity with default constructor.
        /// </summary>
        public MyPlayer() {
            this.player = new WindowsMediaPlayer();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets/Sets: The location of the sound.
        /// </summary>
        public string SoundLocation {
            get => this.player.URL;
            set {
                if (value.GetType() == typeof(string)) {
                    this.player.URL = value;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Plays the sound passed by parameter.
        /// </summary>
        public void Play(string soundName) {
            this.SoundLocation = $"{Environment.CurrentDirectory}\\Sounds\\{soundName}{FORMAT}";
            try {
                this.player.controls.play();
            } catch (Exception e) {
                throw new NoSoundFoundException($"The '{soundName}{FORMAT}' is missing in the Sound's Directory.", e);
            }
        }

        #endregion
    }
}