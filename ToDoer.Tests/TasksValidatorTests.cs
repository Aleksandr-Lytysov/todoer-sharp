using System;
using NUnit.Framework;
using ToDoer.Api.Models;
using ToDoer.Api.Validation;

namespace ToDoer.Tests
{
    public class TaskValidatorTests
    {
        private TasksValidator _target;
        
        [SetUp]
        public void Setup()
        {
            _target = new TasksValidator();
        }

        [Test]
        public void WhenContentIsTooLong_ThenThrowValidationException()
        {
            var task = new Task
            {
                Content =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            };

            Assert.Throws<TasksValidatorException>(() => _target.Validate(task));
        }
        
        [Test]
        public void WhenDueToIsInFuture_ThenThrowValidationException()
        {
            var task = new Task
            {
                Content = "To do smt",
                DueTo = DateTime.UtcNow.AddDays(-1)
            };

            Assert.Throws<TasksValidatorException>(() => _target.Validate(task));
        }   
        
        [Test]
        public void WhenContentIsEmpty_ThenThrowValidationException()
        {
            var task = new Task
            {
                Content = string.Empty
            };

            Assert.Throws<TasksValidatorException>(() => _target.Validate(task));
        }
        
        [Test]
        public void WhenValidTaskPassed_ThenDoNotThrowValidationException()
        {
            var task = new Task
            {
                Content = "To do smt",
                DueTo = DateTime.UtcNow.AddDays(1)
            };

            Assert.DoesNotThrow(() => _target.Validate(task));
        }
    }
}