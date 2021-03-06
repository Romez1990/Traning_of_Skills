﻿using Assets.Scenes.Games.BaseGame;
using Assets.Scenes.Games.BaseGame.Sounds;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scenes {
	public static class Functions {

		public static readonly string[] Games = {
			"FastMath",
			"PreciseCircles",
			"ExactKeystrokes",
			"CircleByCircle"
		};

		public static void LoadGame(string GameName) {
			SceneManager.LoadScene(GameName == "Mixed" || GameName == null ? Games[Random.Range(0, Games.Length)] : GameName);
		}

		public static void ReloadGame() {
			PlayingInfo.Score = 0;
			PlayingInfo.Time = 30;

			LoadGame(PlayingInfo.GameMode);
		}

		public static void Win() {
			Sound.CorrectAnswer();
			PlayingInfo.Time += 10;
			ScoreControl.CalculateAddScore();
			LoadGame(PlayingInfo.GameMode);
		}

		public static void GameOver() {
			Sound.Lose();
			LoadGame("Scoreboard");
		}

		public static readonly string PathToData = Path.Combine(Directory.GetParent(Application.dataPath).ToString(), "Data");

		/// <summary>
		/// Convert CamelCase string to Normal case string
		/// </summary>
		public static string ToNormalCase(this string Str) {
			return string.Concat(Str.Select((x, i) =>
				i == 0 ?
					x.ToString() :
				i > 0 && char.IsUpper(x) ?
					" " + x.ToString().ToLower() :
					x.ToString())
			);

			/*string NewStr = string.Empty;
			for (int i = 0; i < Str.Length; ++i)
				if (i == 0)
					NewStr += Str[i];
				else if (i > 0 && char.IsUpper(Str[i]))
					NewStr += " " + Str[i].ToString().ToLower();
				else
					NewStr += Str[i];

			return NewStr;*/

			// Snake case
			//return string.Concat(Str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();

			//return Regex.Replace(Regex.Replace(Str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
			//return Regex.Replace(Str, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
			//return Regex.Replace(Str, "(\\B[A-Z])", " $1");
			//return Regex.Replace(Str, @"\B[A-Z]", m => " " + m.ToString().ToLower());
		}

	}
}
