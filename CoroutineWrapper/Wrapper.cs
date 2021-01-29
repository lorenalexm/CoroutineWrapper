using System;
using System.Collections;
using UnityEngine;

namespace CoroutineWrapper
{
	public delegate void Callback();

	static public class CoroutineWrapper
	{
		/// <summary>
		/// Waits for a given number of seconds then executes the <see cref="Callback"/>.
		/// </summary>
		/// <param name="seconds">Time in miliseconds to delay</param>
		/// <param name="handler"><see cref="Delegate"/> to be executed</param>
		/// <returns><see cref="IEnumerator"/></returns>
		static public IEnumerator WaitForSeconds(float seconds, Callback handler)
		{
			yield return new WaitForSeconds(seconds);
			handler();
		}

		/// <summary>
		/// Waits for a given number of seconds then executes the <see cref="Callback"/>, looping until canceled.
		/// </summary>
		/// <param name="seconds">Time in miliseconds to delay</param>
		/// <param name="handler"><see cref="Delegate"/> to be executed</param>
		/// <returns><see cref="IEnumerator"/></returns>
		static public IEnumerator WaitForSecondsLoop(float seconds, Callback handler)
		{
			while(true)
			{
				yield return new WaitForSeconds(seconds);
				handler();
			}
		}

		/// <summary>
		/// Waits for a given number of seconds then executes the <see cref="Callback"/>, looping until canceled.
		/// </summary>
		/// <param name="seconds">Time in miliseconds to delay</param>
		/// <param name="delayFirst">Should the delay be executed before the <see cref="Delegate"/> is called?</param>
		/// <param name="handler"><see cref="Delegate"/> to be executed</param>
		/// <returns><see cref="IEnumerator"/></returns>
		static public IEnumerator WaitForSecondsLoop(float seconds, bool delayFirst, Callback handler)
		{
			while(true)
			{
				if(delayFirst == true)
				{
					yield return new WaitForSeconds(seconds);
					handler();
				}
				else
				{
					handler();
					yield return new WaitForSeconds(seconds);
				}
			}
		}
	}
}
