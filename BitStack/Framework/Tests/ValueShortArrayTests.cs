﻿using UnityEngine;
using NUnit.Framework;
using BitStack;
using System;

public class ValueShortArrayTests {
	const int BITS = 16;
	
	static readonly short[] TEST_VALUE_ARRAY = {-12893, -19667, -21398, 25445, 9687, 24398, 27667};
	static readonly int LOOP_COUNT = BITS * TEST_VALUE_ARRAY.Length;
	static readonly int LOOP_COUNT_BYTES = LOOP_COUNT / BITS;
	static readonly int[] EXPTECTED_BITS = CalcBits(TEST_VALUE_ARRAY);
	
	// NOTE -> This is Tested elsewhere and is assumed correct	
	private static int[] CalcBits(short[] value) {
		int[] bits = new int[BITS * value.Length];
		
		int index = 0;
		
		for (int i = 0; i < value.Length; i++) {
			for (int j = 0; j < BITS; j++) {
				bits[index] = value[i].BitAt(j);
				index++;
			}
		}
		
		return bits;
	}
	
	// NOTE -> This is Tested elsewhere and is assumed correct	
	private static short[] GetTestArray() {
		short[] copyArray = new short[TEST_VALUE_ARRAY.Length];      
		Array.Copy(TEST_VALUE_ARRAY, copyArray, TEST_VALUE_ARRAY.Length);
		return copyArray;
	}
	
	[Test]
	public void Test_BitAt() {
		short[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			int bit = TEST_VALUE.BitAt(i);
			
			Debug.Assert(bit == EXPTECTED_BITS[i], 
							"Expected Bit(" + bit + ") at Index(" + i + ") to be " + EXPTECTED_BITS[i]);
		}
	}
	
	[Test]
	public void Test_BitInvAt() {
		short[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			int bit = TEST_VALUE.BitInvAt(i);
			
			Debug.Assert(TEST_VALUE.BitInvAt(i) != EXPTECTED_BITS[i], 
							"Expected Bit(" + bit + ") at Index(" + i + ") not to be " + EXPTECTED_BITS[i]);
		}
	}

	[Test]
	public void Test_SetBitAt() {
		short[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.SetBitAt(i);
			
			Debug.Assert(TEST_VALUE.BitAt(i) == 1,
						 "Expected Bit Position(" + i + ") to be 1");
		}
	}

	[Test]
	public void Test_UnsetBitAt() {
		short[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.UnsetBitAt(i);
			
			Debug.Assert(TEST_VALUE.BitAt(i) == 0,
						 "Expected Bit Position(" + i + ") to be 0");
		}
	}
	
	[Test]
	public void Test_SetBit() {
		short[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.SetBit(i, 0);
			
			Debug.Assert(TEST_VALUE.BitAt(i) == 0,
						 "Expected Bit Position(" + i + ") to be 0");
						 
			TEST_VALUE.SetBit(i, 1);
						 
			Debug.Assert(TEST_VALUE.BitAt(i) == 1,
						 "Expected Bit Position(" + i + ") to be 1");
		}
	}
	
	[Test]
	public void Test_SetUnsetBit() {
		short[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.SetBit(i, 0);
			TEST_VALUE.SetBit(i, 1);
			
			Debug.Assert(TEST_VALUE.BitAt(i) == 1,
						 "Expected Bit Position(" + i + ") to be 1");
						 
			TEST_VALUE.SetBit(i, 1);
			TEST_VALUE.SetBit(i, 0);
						 
			Debug.Assert(TEST_VALUE.BitAt(i) == 0,
						 "Expected Bit Position(" + i + ") to be 0");
		}
	}

	[Test]
	public void Test_ToggleBitAt() {
		short[] TEST_VALUE = GetTestArray();
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.ToggleBitAt(i);
			
			int inv = TEST_VALUE.BitAt(i);
			
			Debug.Assert(TEST_VALUE.BitAt(i) != EXPTECTED_BITS[i],
							"Expected Toggle(" + inv + ") and InvTest(" + EXPTECTED_BITS[i] + ") to not Match.");
		}
		
		for (int i = 0; i < LOOP_COUNT; i++) {
			TEST_VALUE.ToggleBitAt(i);
			
			int inv = TEST_VALUE.BitAt(i);
			
			Debug.Assert(TEST_VALUE.BitAt(i) == EXPTECTED_BITS[i],
							"Expected Toggle(" + inv + ") and InvTest(" + EXPTECTED_BITS[i] + ") to Match.");
		}
	}
}