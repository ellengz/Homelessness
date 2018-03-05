using System.Collections.Generic;
using Responses = System.Collections.Generic.Dictionary<int, string>;

public struct Dialogue {
	public string message;
	public Responses responses;

	public Dialogue(string m, Responses r) {
		message = m;
		responses = r;
	}
}

/*
 * New pages of dialogue should be added to Narrative.dialogueIndex,
 * they require a dialogue ID, a message, and a list of targetID-response pairs (see below)
 * 
 * Open a new dialogue with DialogueBox.Open(id)
 * A target ID of 0 will end the dialogue
 * 
 * If you want to add a whole conversation, please add to the ID range below:
 * 
 * 0: Exit conversation
 * 1-99: casual conversation
 * 101-199: Johnny (homeless1)
 * 
 * To customise an NPC's dialogue, set their NPC.id to the dialogueID you they should start with
 * 
 * */

public static class Narrative {
	private static System.Random random = new System.Random();

	private static int[] Greetings = new int[] { 1, 3, 4 };
	public static int RandomGreeting() {
		return Greetings [random.Next (Greetings.Length)];
	}

	public static Dictionary<int, Dialogue> dialogueIndex = new Dictionary<int, Dialogue> {
		
		{1, new Dialogue ("Hello friend!",
			new Responses {
				{0, "Hi!"},
				{2, "Nice day isn't it?"},
		})},

		{2, new Dialogue ("Yes, lovely weather!",
			new Responses {
				{0, "Goodbye."},
			})},

		{3, new Dialogue ("Who's that man sitting next to the building?",
			new Responses {
					{0, "I don't know. Maybe I should check it out..."},
			})},

		{4, new Dialogue ("Anything I can help you with?",
			new Responses {
				{0, "Nothing..."},
				{5, "I'm lost"},
			})},
					
		{5, new Dialogue ("I'm sorry to hear that.",
			new Responses {
				{0, "..."},
				{6, "Please help"},
			})},
		
		{6, new Dialogue("What are you looking for?",
			new Responses {
				{0, "Nothing..."},
				{7, "Do you know where Salvation Army is?"},
			})},
		{7, new Dialogue("I am not sure. Maybe checkout the buildings one by one?",
			new Responses {
				{0, "Yeah, that sounds like a good idea..."},
			})},
				
		// Johnny
		{101, new Dialogue ("*Cough - cough - cough*",
			new Responses {
				{102, "Are you okay?"},
				{109, "Hi Johnny, I brought you a blanket from the Salvation Army."},
				{220, "I found these job ads, maybe we can get you back on your feet."},
				{0, "*ignore*"},
			})},
		{102, new Dialogue ("*Cough* I think so. I just wish it weren't so cold at night.",
			new Responses {
				{103, "What's your name?"},
				{104, "Do you have somewhere to stay?"},
				{0, "I have to go."},
			})},
		{103, new Dialogue ("I'm Johnny *cough* It's always nice to make a new friend.",
			new Responses {
				{104, "Do you have somewhere to stay?"},
				{0, "It was nice meeting you."},
			})},
		{104, new Dialogue ("I'm on the wait list for a shelter, but there's never enough room.",
			new Responses {
				{105, "So you sleep out here?"},
				{106, "How did this happen?"},
				{0, "I have to go."},
			})},
		{105, new Dialogue ("Yeah... some nights are worse than others.",
			new Responses {
				{107, "I'll see if I can find you a blanket."},
			})},
		{106, new Dialogue ("I fell on rough times, some of it was my fault, some wasn't. Since I lost my job I've been out here.",
			new Responses {
				{105, "So you sleep out here?"},
				{108, "Maybe I can find you some work."},
			})},
		{109, new Dialogue ("Thanks kid.",
			new Responses {
				{0, "No worries."},
				{106, "Glad I could help. How did this happen?"},
			})},
		{220, new Dialogue ("I guess we can try. Let me  have a look.",
			new Responses {
				{0, "Here you go!"},
			})},

		// shop owner salvation army building assistant
		//{111, new Dialogue ("Come on in and see our wonderful selection!",
		{110, new Dialogue("Welcome to Salvation Army! What can I do for you?",
			new Responses {
				{116, "What is the Salvation Army?"},
				{111, "Can you help me with something?"},
				{100, "I need to go."},
			})},
		{111, new Dialogue("What do you need?",
			new Responses {
				{112, "Can I have a blanket for a homeless man?"},
				{114, "I want to help a homeless man to find a job."},
				{110, "Nevermind"},
			})},
		{112, new Dialogue ("I suppose if you help mend a damaged blanket, you can have that...",
			new Responses {
				{300, "Great! Let's go!"},
				{100, "Uh... actually no thanks."},
			})},
		{114, new Dialogue ("We've got a whole pile of newspapers for today, maybe you can look for job advertisement in those newspapers",
			new Responses {
				{115, "Great! Where are they?"},
				{100, "Well... maybe later."},
			})},
		{115, new Dialogue ("They are on the book shelf. It's a big pile... I'm afraid it might take some effort",
			new Responses{
				{200, "That's okay!"},
				{100, "Umm... I'll think about it."},
			})},
		{116, new Dialogue ("The Salvation Army is an international movement and is an evangelical part of the universal Christian Church.",
			new Responses{
				{117, "What are you trying to do?"},
				{111, "Can you help me with something?"},
			})},
		{117, new Dialogue ("Our mission is to preach the gospel of Jesus Christ and meet human needs in His name without discrimination.",
			new Responses{
				{118, "Why are you doing this?"},
				{111, "Can you help me with something?"},
			})},
		{118, new Dialogue ("Our message is based on the Bible. Its ministry is motivated by love of God.",
			new Responses{
				{100, "Sounds great!"},
			})},

		// job hunt game menus
		{201, new Dialogue("Tap to circle anything that looks like a job listing, but avoid any sad or irrelevant news!",
			new Responses{
				{0, "Continue"}
			})},
		{202, new Dialogue("Oh no, you missed some! Well let's take these ones to Johnny anyway.",
			new Responses{
				{100, "Okay"},
			})},
		{203, new Dialogue("You found them all! Now let's go find Johnny.",
			new Responses{
				{100, "Okay"},
			})},

		// blanket game menus
		{301, new Dialogue("We've got a couple damaged blankets here, which one would you like?",
			new Responses{
				{302, "The smaller one..."},
				{303, "The bigger one!"}
			})},
		{302, new Dialogue("Alright, good luck. We're closing in a couple minutes, so be quick!",
			new Responses{
				{0, "I'll do my best!"},
			})},
		{303, new Dialogue("Here you go. We're closing in a couple minutes, so be quick!",
			new Responses{
				{0, "Thanks!"},
			})},
		{304, new Dialogue("Sorry friend, we need to close. You can come back tomorrow though",
			new Responses{
				{100, "Alright..."},
			})},
		{305, new Dialogue("Wow, great job!",
			new Responses{
				{100, "I'll take this straight to Johnny."},
			})},
			
	};
}
