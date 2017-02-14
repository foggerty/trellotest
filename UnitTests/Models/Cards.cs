using System.Collections.Generic;
using AutoMock;
using NUnit.Framework;
using Rhino.Mocks;
using TrelloTest.Controllers;
using TrelloTest.Infrastructure.TrelloClient;
using TrelloTest.Models.Trello;

namespace UnitTests.Models
{
	[TestFixture]
	public class Cards
	{
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

			mock.ClassUnderTest.List("token", "123test");

			mock.Get<ITrelloService>()
				.AssertWasCalled(x => x.List("token", "123test"));
		}
	}
}
