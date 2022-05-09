using Backend.Controllers;
using Backend.Models;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetAllPollsDBConnection()
        {
            PollController a = new(null);
            List<Poll> polls = a.GetPolls();
            string[] titleSet = { "Trump v. Biden 2024FAIL", "Roe v. Wade Public Poll", "Lincoln, Nebraska Mayoral Election", "How separate should church and state be?" };
            Assert.Equal(4, polls.Count);
            for (int i = 1; i < polls.Count; i++)
            {
                Assert.Equal(i + 1, polls[i].pollId);
                Assert.Equal(titleSet[i], polls[i].title);
            }

        }

        [Fact]
        public void TestGetAnswersFromDBConnection()
        {
            AnswerController a = new(null);
            List<Answer> answers = a.GetAnswers("1");
            string[] answerSet = { "Donald J. Trump", "Joseph R. Biden" };
            Assert.Equal(2, answers.Count);
            for (int i = 1; i < answers.Count; i++)
            {
                Assert.Equal(i + 1, answers[i].answerId);
                Assert.Equal(answerSet[i], answers[i].choice);
            }
        }
        [Fact]
        public void TestGetCountFromDBConnection()
        {
            ResponseController a = new(null);
            Assert.Equal(a.GetCount(1, 1), "[{\"choice\":\"Donald J. Trump\",\"responseId\":19,\"sum\":3},{\"choice\":\"Joseph R. Biden\",\"responseId\":32,\"sum\":2}]");
        }
        [Fact]
        public void TestGetUsersFromDBConnection()
        {
            UserController a = new(null);
            User found = a.GetUser("admin", "admin");
            Assert.Equal(found.voterId, "admin");
        }
    }
}