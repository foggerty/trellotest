using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMock;
using NUnit.Framework;
using Rhino.Mocks;
using TrelloTest.Controllers;
using TrelloTest.Infrastructure.Trello;
using TrelloTest.Models.Trello;

namespace UnitTests
{
	[TestFixture]
	public class Cards
	{
		// There's so little worth testing in this project!
		// This is more about demonstrating that I'm famaliar with the standard
		// practices/tooling.

		private RhinoAutoMocker<CardsController> NewMock()
		{
			return new RhinoAutoMocker<CardsController>();
		}

		private List<TrelloTuple> NewList()
		{
			return new List<TrelloTuple>
				{
					new TrelloTuple {Id="1", Label ="ABC" },
					new TrelloTuple {Id="2", Label ="DEF" }
				};
		}

		[Test]
		public void When_listing_cards_Trello_should_be_called()
		{
			var mock = NewMock();

			mock.ClassUnderTest.Cards("123test");

			mock.Get<ITrelloQuery>()
				.AssertWasCalled(x => x.AllCards("123test"));
		}
	}
}
