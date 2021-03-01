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

		/// <summary>
		/// Enters into a loop until the value is lesser or greater than the limit, processed every frame.
		/// Loop condition is determined by the value being lower or higher than the limit.
		/// </summary>
		/// <param name="value">Value to pass to the loopHandler <see cref="Delegate"/></param>
		/// <param name="limit">Upper or lower limit to be compared to the value</param>
		/// <param name="adjustedBy">Amount the value will be changed each cycle</param>
		/// <param name="loopHandler"><see cref="Delegate"/> to be executed within the loop.</param>
		/// <param name="postHandler">Optional <see cref="Delegate"/> to be executed after the loop completes</param>
		/// <returns><see cref="IEnumerator"/></returns>
		static public IEnumerator LoopUntil(float value, float limit, float adjustedBy, Callback loopHandler, Callback postHandler = null)
		{
			if(value > limit)
			{
				while (value >= limit)
				{
					value -= adjustedBy;
					loopHandler();
					yield return new WaitForEndOfFrame();
				}
			}
			else
			{
				while (value <= limit)
				{
					value += adjustedBy;
					loopHandler();
					yield return new WaitForEndOfFrame();
				}
			}
			

			postHandler?.Invoke();
		}

		/// <summary>
		/// Enters into a loop until the value is equal
		/// </summary>
		/// <param name="value">Value to pass to the loopHandler <see cref="Delegate"/></param>
		/// <param name="equals">Boolean value to compare to the value parameter</param>
		/// <param name="loopHandler"><see cref="Delegate"/> to be executed within the loop.</param>
		/// <param name="postHandler">Optional <see cref="Delegate"/> to be executed after the loop completes</param>
		/// <returns><see cref="IEnumerator"/></returns>
		static public IEnumerator LoopUntil(bool value, bool equals, Callback loopHandler, Callback postHandler = null)
		{
			while(value != equals)
			{
				loopHandler();
				yield return null;
			}

			postHandler?.Invoke();
		}

		/// <summary>
		/// Starts a one-off coroutine to run in the background
		/// </summary>
		/// <param name="loopHandler"><see cref="Delegate"/> to be executed.</param>
		/// <returns><see cref="IEnumerator"/></returns>
		static public IEnumerator Background(Callback loopHandler)
		{
			loopHandler();
			yield return null;
		}
	}
}
