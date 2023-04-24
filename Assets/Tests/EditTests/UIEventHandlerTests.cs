using FrogSurvive.Events;
using NUnit.Framework;
using Scripts;

public class UIEventHandlerTests
{
	[Test]
	public void ShouldRaiseResetEvent_WhenResetButtonClicked()
	{
		//Arrange
		var eventBusSpy = new EventBusSpy<ResetButtonClickedUISignal>();
		var uiEventHandlerGameObject = TestGameObject.GetNew();
		var uiEventHandler = uiEventHandlerGameObject.AddComponent<UIEventHandler>();
		uiEventHandler.Construct(eventBusSpy);
		//Act
		uiEventHandler.OnResetButtonClicked(TestGameObject.GetNew());
		var (isEventFired, _) = eventBusSpy.IsExpectedEventFired();
		//Assert
		Assert.IsTrue(isEventFired);
	}
}