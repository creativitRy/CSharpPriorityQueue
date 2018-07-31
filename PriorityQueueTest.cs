using System.Linq;
using CloudCanards.Core.Algorithms;
using NUnit.Framework;

namespace CloudCanards.Core.Test.Editor
{
	[TestFixture]
	public class PriorityQueueTest
	{
		[TestCase(new[] {5, 2, 3, 1, 7, 3, 5, 5, 5})]
		[TestCase(new[] {5})]
		[TestCase(new[] {5, 6})]
		[TestCase(new[] {6, 5})]
		[TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9})]
		[TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9})]
		[TestCase(new[] {99, 88, 77, 66, 55, 44, 33, 22, 11})]
		[TestCase(new[] {-999, 999, int.MaxValue, int.MinValue})]
		[Test]
		public void Remove(int[] nums)
		{
			var ans = nums.ToList();
			ans.Sort();

			var queue = new PriorityQueue<int>();
			var addCount = 0;
			Assert.AreEqual(queue.Count, addCount);
			foreach (var num in nums)
			{
				addCount++;
				queue.Add(num);
				Assert.AreEqual(queue.Count, addCount);
			}

			Assert.AreEqual(queue.Count, nums.Length);

			foreach (var num in ans)
			{
				var test = queue.Remove();
				Assert.AreEqual(num, test);
			}

			Assert.AreEqual(queue.Count, 0);
		}

		[TestCase(new[] {5, 2, 3, 1, 7, 3, 5, 5, 5})]
		[TestCase(new[] {5})]
		[TestCase(new[] {5, 6})]
		[TestCase(new[] {6, 5})]
		[TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9})]
		[TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9})]
		[TestCase(new[] {99, 88, 77, 66, 55, 44, 33, 22, 11})]
		[TestCase(new[] {-999, 999, int.MaxValue, int.MinValue})]
		[Test]
		public void PeekAndRemove(int[] nums)
		{
			var ans = nums.ToList();
			ans.Sort();

			var queue = new PriorityQueue<int>();
			foreach (var num in nums)
			{
				queue.Add(num);
			}

			Assert.AreEqual(queue.Count, nums.Length);

			foreach (var num in ans)
			{
				var count = queue.Count;
				Assert.AreEqual(num, queue.Peek());
				Assert.AreEqual(count, queue.Count);
				var test = queue.Remove();
				Assert.AreEqual(num, test);
				Assert.AreEqual(count - 1, queue.Count);
			}

			Assert.AreEqual(queue.Count, 0);
		}

		[TestCase(new[] {5, 2, 3, 1, 7, 3, 5, 5, 5})]
		[TestCase(new[] {5})]
		[TestCase(new[] {5, 6})]
		[TestCase(new[] {6, 5})]
		[TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9})]
		[TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9})]
		[TestCase(new[] {99, 88, 77, 66, 55, 44, 33, 22, 11})]
		[TestCase(new[] {-999, 999, int.MaxValue, int.MinValue})]
		[Test]
		public void Contains(int[] nums)
		{
			var queue = new PriorityQueue<int>();
			foreach (var num in nums)
			{
				queue.Add(num);
				Assert.IsTrue(queue.Contains(num));
			}

			foreach (var num in nums)
			{
				Assert.IsTrue(queue.Contains(num));
			}

			for (var i = -10; i <= 10; i++)
			{
				if (nums.Contains(i))
					continue;
				Assert.IsFalse(queue.Contains(i));
			}
		}

		[TestCase(new[] {5, 2, 3, 1, 7, 3, 5, 5, 5}, 6)]
		[TestCase(new[] {5}, 5)]
		[TestCase(new[] {5}, 6)]
		[TestCase(new[] {5, 6}, 6)]
		[TestCase(new[] {6, 5}, 6)]
		[TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 10)]
		[TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 4)]
		[TestCase(new[] {99, 88, 77, 66, 55, 44, 33, 22, 11}, 11)]
		[TestCase(new[] {-999, 999, int.MaxValue, int.MinValue}, int.MaxValue)]
		[Test]
		public void Remove(int[] nums, int remove)
		{
			var ans = nums.ToList();
			ans.Sort();
			var removed = ans.Remove(remove);

			var queue = new PriorityQueue<int>();
			foreach (var num in nums)
			{
				queue.Add(num);
			}

			Assert.AreEqual(removed, queue.Remove(remove));

			foreach (var num in ans)
			{
				var test = queue.Remove();
				Assert.AreEqual(num, test);
			}
		}
	}
}