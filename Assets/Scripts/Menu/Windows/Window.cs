﻿using UnityEngine;

public abstract class Window : MonoBehaviour
{
	public abstract void Initialize();

	public virtual void Hide() => gameObject.SetActive(false);

	public virtual void Show() => gameObject.SetActive(true);
}
