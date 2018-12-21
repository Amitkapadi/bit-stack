﻿#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

#if NET_4_6 && !BITSTACK_DISABLE_INLINE
#define BITSTACK_METHOD_INLINE
#endif

#if BITSTACK_METHOD_INLINE
using System.Runtime.CompilerServices;
#endif

namespace BitStack {
	
	/**
	 * An Extension of the ValueULongExtension which allows working with bits
	 * on an array of values. All functionality is piped directly to the
	 * ValueULongExtension whenever possible. 
	 *
	 * Since Arrays are a reference type, some functions will not return 
	 * anything and will modify the array value directly.
	 *
	 * NOTICE ABOUT PERFORMANCE
	 * 
	 * UNITY_EDITOR or DEBUG flags ensure that common errors are caught. These
	 * flags are removed in production mode so don't rely on try/catch methods.
	 * If performing benchmarks, ensure that the flags are not taken into account.
	 * The flags ensure that common problems are caught in code and taken care of.
	 *
	 * CRITICAL CHANGES
	 * 20/12/2018 - for .NET 4.6 targets, all functions are hinted to use AggressiveInlining
	 */
	public static class ValueULongArrayExtensions {
		const int BIT_LEN = 64;
		const int BYTE_LEN = BIT_LEN / 8;
		
		/**
		 * Return the state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, data.Length * 64]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitAt(this ulong[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("ulong[].BitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ulong[].BitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ulong[].BitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			return data[bitIndex].BitAt(pos % BIT_LEN);
		}
		
		/**
		 * Return the inverted state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, data.Length * 64]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitInvAt(this ulong[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("ulong[].BitInvAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ulong[].BitInvAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ulong[].BitInvAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			return data[bitIndex].BitInvAt(pos % BIT_LEN);
		}

		/**
		 * Sets the state of the bit into the ON/1 at provided
		 * position. position value must be between [0, data.Length * 64]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetBitAt(this ulong[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("ulong[].SetBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ulong[].SetBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ulong[].SetBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].SetBitAt(pos % BIT_LEN);
		}

		/**
		 * Sets the state of the bit into the OFF/0 at provided
		 * position. position value must be between [0, data.Length * 64]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void UnsetBitAt(this ulong[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("ulong[].UnsetBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ulong[].UnsetBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ulong[].UnsetBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].UnsetBitAt(pos % BIT_LEN);
		}

		/**
		 * Toggles the state of the bit into the ON/1 or OFF/0 at provided
		 * position. position value must be between [0, data.Length * 64].
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void ToggleBitAt(this ulong[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("ulong[].ToggleBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ulong[].ToggleBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ulong[].ToggleBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].ToggleBitAt(pos % BIT_LEN);
		}
		
		/**
		 * Sets the state of the bit into the OFF/0 or ON/1 at provided
		 * position. position value must be between [0, data.Length * 64]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetBit(this ulong[] data, int pos, int bit) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("ulong[].SetBit(int, int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ulong[].SetBit(int, int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("ulong[].SetBit(int, int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].SetBit(pos % BIT_LEN, bit);
		}

		/**
		 * Count the number of set bits in the provided ulong array (64 bits)
		 * A general purpose Hamming Weight or popcount function which returns the number of
		 * set bits in the argument.
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int PopCount(this ulong[] data) {
			#if BITSTACK_DEBUG
				if (data == null) {
					BitDebug.Exception("ulong[].PopCount() - array is null");
				}
			#endif
			
			int counter = 0;
			int length = data.Length;
			
			for (int i = 0; i < length; i++) {
				counter += data[i].PopCount();
			}
			
			return counter;
		}

		/**
		 * Returns the byte (8 bits) at provided position index
		 * Position value must be between [0, data.Length * 8]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ByteAt(this ulong[] data, int pos) {
			int byteIndex = pos / BYTE_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("ulong[].ByteAt(int) - byte position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ulong[].ByteAt(int) - array is null");
				}
				
				if (byteIndex > data.Length) {
					BitDebug.Exception("ulong[].ByteAt(int) - byte bucket must not be greater than array " + data.Length + " was " + byteIndex);
				}
			#endif
			
			return data[byteIndex].ByteAt(pos % BYTE_LEN);
		}

		/**
		 * Sets and returns the byte (8 bits) at provided position index
		 * Position value must be between [0, data.Length * 8]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetByteAt(this ulong[] data, byte newData, int pos) {
			int byteIndex = pos / BYTE_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("ulong[].SetByteAt(byte, int) - byte position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("ulong[].SetByteAt(byte, int) - array is null");
				}
				
				if (byteIndex > data.Length) {
					BitDebug.Exception("ulong[].SetByteAt(byte, int) - byte bucket must not be greater than array " + data.Length + " was " + byteIndex);
				}
			#endif
			
			data[byteIndex] = data[byteIndex].SetByteAt(newData, pos % BYTE_LEN);
		}
	}
}
