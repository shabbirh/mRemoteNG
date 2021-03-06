﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Extensions.Forms;
using System.Threading.Tasks;
using mRemoteNG.Forms;
using mRemoteNG.UI.Forms;

namespace mRemoteNGTests.UI.Forms
{
    [TestFixture]
    public class PasswordFormTests
    {
        PasswordForm _passwordForm;

        [SetUp]
        public void Setup()
        {
            _passwordForm = new PasswordForm();
            _passwordForm.Show();
        }

        [TearDown]
        public void Teardown()
        {
            _passwordForm.Dispose();
            while (_passwordForm.Disposing) ;
            _passwordForm = null;
        }

        [Test]
        public void PasswordFormText()
        {
            FormTester formTester = new FormTester("PasswordForm");
            Assert.That(formTester.Text, Does.Match("Password"));
        }

        [Test]
        public void ClickingCancelClosesPasswordForm()
        {
            bool eventFired = false;
            _passwordForm.FormClosed += (o, e) => eventFired = true;
            ButtonTester cancelButton = new ButtonTester("btnCancel", _passwordForm);
            cancelButton.Click();
            Assert.That(eventFired, Is.True);
        }
    }
}