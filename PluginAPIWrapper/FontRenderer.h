/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */ 
#include "agsplugin.h"

typedef bool (*LoadFromDiskCallback)(int fontNumber, int fontSize);
typedef void (*FreeMemoryCallback)(int fontNumber);
typedef bool (*SupportsExtendedCharactersCallback)(int fontNumber);
typedef int (*GetTextWidthCallback)(const char *text, int fontNumber);
typedef int (*GetTextHeightCallback)(const char *text, int fontNumber);
typedef void (*RenderTextCallback)(const char *text, int fontNumber, BITMAP *destination, int x, int y, int colour);
typedef void (*AdjustYCoordinateForFontCallback)(int *ycoord, int fontNumber);
typedef void (*EnsureTextValidForFontCallback)(char *text, int fontNumber);

class FontRenderer : public IAGSFontRenderer
{
private:
	LoadFromDiskCallback loadFromDiskCallback;
	FreeMemoryCallback freeMemoryCallback;
	SupportsExtendedCharactersCallback supportsExtendedCharactersCallback;
	GetTextWidthCallback getTextWidthCallback;
	GetTextHeightCallback getTextHeightCallback;
	RenderTextCallback renderTextCallback;
	AdjustYCoordinateForFontCallback adjustYCoordinateForFontCallback;
	EnsureTextValidForFontCallback ensureTextValidForFontCallback;

public:
	FontRenderer(
		LoadFromDiskCallback lfdc, FreeMemoryCallback fmc,
		SupportsExtendedCharactersCallback secc, GetTextWidthCallback gtwc,
		GetTextHeightCallback gthc, RenderTextCallback rtc, AdjustYCoordinateForFontCallback acffc,
		EnsureTextValidForFontCallback etvffc)
	{
		loadFromDiskCallback = lfdc;
		freeMemoryCallback = fmc;
		supportsExtendedCharactersCallback = secc;
		getTextWidthCallback = gtwc;
		getTextHeightCallback = gthc;
		renderTextCallback = rtc;
		adjustYCoordinateForFontCallback = acffc;
		ensureTextValidForFontCallback = etvffc;
	}

  virtual bool LoadFromDisk(int fontNumber, int fontSize)
  {
	  return (*loadFromDiskCallback)(fontNumber, fontSize);
  }

  virtual void FreeMemory(int fontNumber)
  {
	  (*freeMemoryCallback)(fontNumber);
  }

  virtual bool SupportsExtendedCharacters(int fontNumber)
  {
	  return (*supportsExtendedCharactersCallback)(fontNumber);
  }

  virtual int GetTextWidth(const char *text, int fontNumber)
  {
	  return (*getTextWidthCallback)(text, fontNumber);
  }

  virtual int GetTextHeight(const char *text, int fontNumber)
  {
	  return (*getTextHeightCallback)(text, fontNumber);
  }

  virtual void RenderText(const char *text, int fontNumber, BITMAP *destination, int x, int y, int colour)
  {
	  (*renderTextCallback)(text, fontNumber, destination, x, y, colour);
  }

  virtual void AdjustYCoordinateForFont(int *ycoord, int fontNumber)
  {
	  (*adjustYCoordinateForFontCallback)(ycoord, fontNumber);
  }

  virtual void EnsureTextValidForFont(char *text, int fontNumber)
  {
	  (*ensureTextValidForFontCallback)(text, fontNumber);
  }
};