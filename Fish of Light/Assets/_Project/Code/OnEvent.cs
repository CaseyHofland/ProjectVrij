﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEvent : MonoBehaviour
{
	[SerializeField] private EventTrigger eventStartTrigger = EventTrigger.None;
	//[SerializeField] private EventTrigger eventStopTrigger = EventTrigger.None;
	[SerializeField] private String CollisionTag = "";
	[SerializeField] private bool triggerOnce = false;
	[SerializeField] private UnityEvent unityEvent;

	private bool hasTriggered = false;

	public enum EventTrigger
	{
		None,
		ObjectStart,
		ObjectDestroy,
		TriggerEnter,
		TriggerExit,
		TriggerEnter2D,
		TriggerExit2D,
		CollisionEnter,
		CollisionExit,
		CollisionEnter2D,
		CollisionExit2D,
		ObjectEnable,
		ObjectDisable,
		MouseEnter,
		MouseExit,
		MouseDown,
		MouseUp,
	}

	private void Start()
	{
		HandleGameEvent(EventTrigger.ObjectStart);
	}

	private void OnDestroy()
	{
		HandleGameEvent(EventTrigger.ObjectDestroy);
	}

	private void OnEnable()
	{
		HandleGameEvent(EventTrigger.ObjectEnable);
	}

	private void OnDisable()
	{
		HandleGameEvent(EventTrigger.ObjectDisable);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (String.IsNullOrEmpty(CollisionTag) || other.CompareTag(CollisionTag))
		{
			HandleGameEvent(EventTrigger.TriggerEnter);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (String.IsNullOrEmpty(CollisionTag) || other.CompareTag(CollisionTag))
		{
			HandleGameEvent(EventTrigger.TriggerExit);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (String.IsNullOrEmpty(CollisionTag) || other.CompareTag(CollisionTag))
		{
			HandleGameEvent(EventTrigger.TriggerEnter2D);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (String.IsNullOrEmpty(CollisionTag) || other.CompareTag(CollisionTag))
		{
			HandleGameEvent(EventTrigger.TriggerExit2D);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (String.IsNullOrEmpty(CollisionTag) || collision.transform.CompareTag(CollisionTag))
		{
			HandleGameEvent(EventTrigger.CollisionEnter);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (String.IsNullOrEmpty(CollisionTag) || collision.transform.CompareTag(CollisionTag))
		{
			HandleGameEvent(EventTrigger.CollisionExit);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (String.IsNullOrEmpty(CollisionTag) || collision.transform.CompareTag(CollisionTag))
		{
			HandleGameEvent(EventTrigger.CollisionEnter2D);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (String.IsNullOrEmpty(CollisionTag) || collision.transform.CompareTag(CollisionTag))
		{
			HandleGameEvent(EventTrigger.CollisionExit2D);
		}
	}

	private void OnMouseEnter()
	{
		HandleGameEvent(EventTrigger.MouseEnter);
	}

	private void OnMouseExit()
	{
		HandleGameEvent(EventTrigger.MouseExit);
	}

	private void OnMouseDown()
	{
		HandleGameEvent(EventTrigger.MouseDown);
	}

	private void OnMouseUp()
	{
		HandleGameEvent(EventTrigger.MouseUp);
	}

	private void HandleGameEvent(EventTrigger gameEvent)
	{
		if (triggerOnce && hasTriggered)
		{
			return;
		}

		if (eventStartTrigger == gameEvent)
		{
			Play();
			hasTriggered = true;
		}
		/*
		if (eventStopTrigger == gameEvent)
		{
			Stop();
		}
		*/
	}

	private void Play()
	{
		unityEvent.Invoke();
	}

	private void Stop()
	{
	}
}
