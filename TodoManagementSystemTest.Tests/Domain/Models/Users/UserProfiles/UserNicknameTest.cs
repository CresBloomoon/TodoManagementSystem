using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Domain.Models.Shared;
using TodoManagementSystem.Domain.Models.Users.UserProfiles;

namespace TodoManagementSystemTest.Tests.Domain.Models.Users.UserProfiles
{
    internal sealed class UserNicknameTest
    {
        private const string UserNickname51Chars =
            "この文章はダミーです。文字の大きさ、量、字間、行間等を確認するために入れています。この文章はダミーです";

        [Test]
        public void 引数に50文字以内の文字列を渡すとインスタンスが生成される()
        {
            //Arrange
            const string userNicknameValue = "ニックネーム";

            //Act
            var userNickname = new UserNickname(userNicknameValue);

            //Arrange
            Assert.That(userNickname.Value, Is.EqualTo(userNicknameValue));
        }

        [TestCase(UserNickname51Chars, TestName = "引数に51文字以上の文字列を渡すと例外が発生する")]
        [TestCase("", TestName = "引数に空の文字列を渡すと例外が発生する")]
        [Test]
        public void 引数に不正な文字列を渡すと例外が発生する(string nickname)
        {
            //Arrange
            //テストケースにてArrange済

            //Act
            //Assert
            Assert.That(
                () => new UserNickname(nickname),
                Throws.TypeOf<DomainException>());
        }
    }
}
