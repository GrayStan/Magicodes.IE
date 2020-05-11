﻿using Magicodes._64;
using Magicodes.ExporterAndImporter.Attributes;
using Magicodes.ExporterAndImporter.Tests.Models.Export;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MagicodesWebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MagicodesController : ControllerBase
    {
        [HttpGet("excel")]
        [Magicodes(Type = typeof(StudentExcel))]
        public List<StudentExcel> Excel()
        {
            var list = new List<StudentExcel>
            {
                new StudentExcel
                {
                    Name = "MR.A",
                    Age = 18,
                    Remarks = "我叫MR.A,今年18岁",
                    Birthday = DateTime.Now
                },
                new StudentExcel
                {
                    Name = "MR.B",
                    Age = 19,
                    Remarks = "我叫MR.B,今年19岁",
                    Birthday = DateTime.Now
                },
                new StudentExcel
                {
                    Name = "MR.C",
                    Age = 20,
                    Remarks = "我叫MR.C,今年20岁",
                    Birthday = DateTime.Now
                }
            };
            return list;
        }

        [HttpGet("pdf")]
        [Magicodes(Type = typeof(BatchPortraitReceiptInfoInput), TemplatePath = ".//ExportTemplates//batchReceipt.cshtml")]
        public BatchPortraitReceiptInfoInput Pdf()
        {

            var input = new BatchPortraitReceiptInfoInput
            {
                Payee = "湖南心莱信息科技有限公司",
                SealUrl =
                @"data:image/jpeg;base64,R0lGODlheAB4APcAAEMAAPf395mZmZJQUPUBAdbW1swAAP+Zma0AAISEhPUqKry8vMwqKpkAAP9SUv97e64wMP+ZzElJSeBRUf/N4+F6esOgoPD///cREc8YGO/v7/dDQ2YAANJTU/9mZtk5Oc5+frMPD94AAPju7tS/v6Wlpe6traMYGO/Pz99ra3d3d+XW1syZmWMQEP/98NOTk+8bG/bm5v+MjNBCQvYZGf9mZsR0dMzMzN8PD/bFxfc5OeEoKPcICL0AAOFhYZx8fPi9vcFRUbBAQKysrHUAAP///+AYGM4QEOjFxe9DQ2YzM++MjMysrLQgIPbe3lsAAPd6eqUAALyMjOVCQsOvr/Gmprlpaebm5twICPYwMPZJSe23t6FhYd7e3vohIatra/Vra1IAAP+FhaaGht0xMcxmZvfX184ICP9aWutZWY8REfRkZOU6OsU4OIMbG+x8fMXFxcUQEN4gIO8QELwICP/398BhYcwzM7UAAOmcnMNDQ7W1tf/MzIyMjKhQUN1ISO8ICP+lpf8ICPhTU4MAAOSSkswgIOxsbNhsbOcAAGkgIOCwsPAhIbuAgN/AwOXf397Pz+4qKp2NjecyMsuLi//v76t7e5ODg4cwMLUcHNycnKMrK/8QEP+1tWMICOKMjOdKSv86OtYAALMwMLOQkPZycteEhP8ZGcQAAP8hIbdhYZkAAP8pKf/m5v9KSvBRUX4NDfaWlv/e3sMYGP+trb4hIcy8vO7f3+V0dOYZGfaFhapwcOUICOYgILxBQf8zM+bQ0PJLS/+9vcWUlLwQELpaWv/Fxf9zc7MICP9CQtivr9YwMOjAwPdZWe8AAMlJScSkpOdjY/A6OtUREdhYWHQQEKEgINYnJ9YJCZtbW+coKP8AAOYPD86FhduysvikpNQZGf/W1rV1dfCDg7hSUuajo946Ou8yMtSkpNRkZMYHB/FxcY19ffbNzeKCgsi4uPmMjEsAANO1tdhAQNNzc8AwMMQgIPm0tOZQUL0XF9QgIMKCgrVBQe6Vlbl5efatrSH5BAQUAP8ALAAAAAB4AHgAAAj/AIsIHEiwoMGDCBMqXMiwocOHECNKnEixosWLGDNq3Mixo8ePIEOKHEmypMmOfGiJOZYsWaptMGOmanlMDC0+J3NCrESLpaBTv1x5kEHLmKw6Req0kmWM1oFjDlhxEpTsGK1KOrMSlCXjlyBWHmi1otiKlgepv2TI0mqyUleqB8YerIQ0YqsDyTilxcr2Ix8P20LRUlhHjINkHg4YrVvJiZOFd716wNlXo7C8HsIxpOUg1C9WoBkZMRKJzQdHDsOhoSqsssXLqcTIbfgNTSoMgABho6OHjByJlR6cStba9U4PnI7NfhhOATd7LBxpKBItBUVZxzh54Gt8oQxODpZD/+ykII41a0d2VJJWzmI4B6dkdE8oKxmr4gLDiV9YSUEGSkUkoUMruSCBES3DrTUfQQekcgx3An2zRkSdnDMFFNu1I8IIGbXiwSmBLCgQcp0cVIcOxjhUiTE8fZPDCE70I4IjIICAmooCtaLZQJ2c4sF8lQSl4EE9DXQUQoGg0ZkX3MRBBx0GRImAKtM11EkyD4jxixdvbOUZhFrxccqDA4UjRopJBRKIK3zIkAwjaSDUGSun8GBAFFE0oQcxCJDAkDDF1eGKK1vOgU2VOTrACWVhcvJAQR4cRhcayXzGypY4dJBQOFrwYKcFA+kRBSQM/fKLLgLR4goMvKgzCqIDff/HaE60sBJiQbQkE4oMwtDJCQ005KCDCEcoNA5uIhgwj0CfINNQKKx4IYZq0sSBQAPiICQGJ4PRKki3BomRzCl15EYABlUk0Q43BmiSkBNz8JCEO6IwU0QecTR0gBf8spJFBids0gACiyBEC7cniXmrnBj48IIBIjhzzzlLoHCHIQoFA8gceRgATBFVZODQNwpggBsqoDIUyCmzhqQwQrJ0wocxc8ShgR0QTwLMEcrY0YNCOfAiQgejPAIyOA/BC4gIPURRzycoBKCQDCyPVAknYiTkChquVJIEHqCmIAoq++xDDgmkKrTFPEFAskIa60wDESO8eONNI/y0cYQcEyb/9AAnYHb0yzF1HXRAFjS8wgwCEAjETAfoFFEPExEBwQbGD32Dgx6wMlQHGr+E5EEyDJXCiwGQ8IOA0QQBU0vnDI3AoUOtBFAIOOC8sNMvP3rU4I4LuTPDIyQgEHlBwKTj8hoTjkBGDzNAFE4qC2skC8IRGWLHQbeE1IkrOnwzRRxR1BJRIJwMmVFVE1XQhntmRCTLZ6B0MwzrEVG6kQysFA7RLcWqiC5iIBEw5KIM+ANOfDJyNfxEBBf5okg40oACiQTgDz1QhkV6FDiJRKoiAdAdRWiBD+uwxQG9q4gwBKG+nMhgDWSYXUn4gIbe8YETDpQI+8J0ACgsowIlcUtn/xgRvyKMToWAE4gxDkCLTqBpIMbohFOeiBEZHKAU14iDDEEiDK79ggZYaE8RWiGIHD4ES1AUQ5YUA8UDqPFMReigXayIRTyI8COtgIoOGDGH093IiKSTiJhm04mV1IQWD0ikSo5RkxJlpBMHkEEaZoEA830kEM1IQi+mQYc73KEHfyRjyxrigd5hpZDHEMANbnCAVq5SAI3UiBhkAIU/8AkP7uJIHkFxjSOogx+PgIQB1KHBgaAwIpUQBPCK0AkBCMAF0IxmNJ3pyIuEQwYyEMMkEYAAPXBEGGsABQNsAIlaWJIN0zAFQfggCDkiRAahIIgzpUlPaTqzitiUARgMwf9NUGrEGK+IBhsCWAE5BKAVSZiGpgjCCvk85BcHGMgz60nRaVqkErPE5j7xwNEyaCQJBVuCEbZQBCec4xyTWMYZUAGrrjxEFu0UyEQrSlMBqDCf+jQERznavY305xX/AIU+4oAODaQAG4UgSCvS5xAZrLIIM6VpTYvwVIjgNKc7xQM9OgIPBZijGzaggzyKMIJe7KAgu3LIDS5wgahKtaZsvcFD7oJTLeh0p8SAXUViIY0dzGI65tBUHYIBjqTGKnQMqcRa2/rWxgogrg9RUyuxeQocZLUHd7xoKZYQAySgQlOySAIUBrEDYnhzIGR050AW61YXSEACNH1tPR97Abn/KqQSleBDIGgRiFYChgA9CG5wwZEGDwSiE8jlQyuW28KEHAA/S+iFhKZgDgaEoAH7KEgqwJUQ1kYzAi6IgGwr+lrwgheatJXrcsMhDJWIoZTHWONueXsAV8CEacE9gxEUkAwHoOG//3WAKyplKh2kIRr32BRS2iGNSTAgH/WwgQUSKBAHHGMh3nUBBSKwYQo0VsMc5rALbpDeRDKylPCN7yyZSAunnAImBEAFKs6AA0boYGsADnBLkjGJSdyhCTZIiDH4UIclTCIDmVCFn5wbSISsda0z9bCH6wnbekoZmiSubW1NjGIPMDKR2NztmmKyjUQYABu54K9/c4wGLbCB/wwMOIEa1AANhcBjHHfIRBteoNeCyGIbClklW1tL0SpLNcu1vUEzFj2IGno5vlmyYn3JDBNncMPG/f3vIEDxhz/cwRpqgAUHOJCyhOBiFk0odUMWpRBavPLDhqYpiVcZiV70Qg64loYWBuGBRD6glK54MaVjgoFLJWMDU2iDNdzghmo8IQxhqEbaFBKAFUhkuwoRgyug+uEPk1ggQNAGDqJkgGkYQRu7Htew101pYlQjDACINwDi0YJpeyQUWUsII7nd7UN/WyBmuAa5o4QNI8yB3QiHCR7gLe94K4HCHfGyQpLhUEL3G8s2JcgIljFwUXjcGQlfNx6eEI+GA0AJff/eiLgmXhyL9/uVB/GBx0WBjZpjA+Qhj0kPng3teIdhACnfCF4UkgrgubyxMEdIObCABZtjAweAyHmZOcBzaIeBCybpRCoUso3lHL2iq/x3QpBgBByYHQe5yIUgco6HUT/h7U+wRMIAnZBtgGmeSA/7PRkSgymMBgaMYAQGct6AURte1ST5M9cR4kxVhv3xet+7QwJwiEhEIgtZYAXhicB5IuzCZXIRhlwqQXeEbMN/Bmm86lVPkXboQAct+UXOo0CI2hPCDxhxYCs6IYwg6aAIwngFPgRCeq7vZyT1dYDyk5HzazXg+SGwpgfGUt8Bf4YGcygCGMhwBoEovu7NHcn/e1Fs35Dj4fnot7dEAuGBQpqKFTTAgKek8Q8dgMMeAuFD6Q+SCiqWBA0n5gGDABOJcH7PhwA9YAAgZwDo93wAUhFcczhz0EdMlwgWOAcwcAQgkCpblxDJwF0kUQmMNIKgwAtRYHhEQAjohwAGkAh48oJBQBF1IAsO8AvBIAIyZwqI0AtYECVYwAtHUCVuMnEOhRBUcIRImIRUMBF84GsPUApk4AZvN2opqIJRwE3c9IJRgAcU4QGm4gU8kAjlwAyfAArjYAAQYAM/aAhV8gBNdhD7dhBKOIdJGBGIlEilQA3W4AlwxwFV2ABXuFMIoIV/JBE6MAfRkAhAUAWv4AVA/4AK5FAEjAAD6hCDRQCA2eYARkiHdBgRMuBr1LAJnmB1T+CHtYcnWYUHWriBFIEPGeAIIsAMG6AFc4AEBpAOAaADO4AMTSAQyZBvBsMKCsGJSDgRkHYIEDCKpFgNFqAB4sBNeCBcPTCIeOILFfEJxFAEvJAIjNALM+AIBoAFMLAD+QABaYNtCXFDJyGCjNQBbmB1YfAEQDcQwKAH0tgDeICFCBB0CjECHeAEJoADotA0JIAK9GAKdMAPBCEIo1QQ7dQKqPcRwsBIE7CHVqcIS2gQi2AI0piPg1hMFjEC9MA4RUA2j4AACpkj+4cQHxhHJPEU0SCK0PYEu5ByI2AKcf+QVXgSZBlxC9NRBtkVB9YoEEO3EMeABkUgNSNRSjMAC/HoBku2ELdQBvjIUVEwCh0BDB+TDkNZBK5wYQtRKyVRB83wB9YwanIHEY7wSaoYBfxIEY4AkqcAgnMhCMfXEbIACnuICer3EJpADFHQAIjnEX+mWgMBUSTxDXfgBqRwERoAAlGgCiPxAIjFEPBEEtEQBBBHEbewPSLRUA4BU4aJEQUjIgsBU+GHEIhpmpWhJVYljKzJFnUAmg9BessUmyfRCTEFER6AlLipE8cUEex0l7/5EdfTkAyBRiERAMyplBHRnCRxRBMhDKmQmhcBBKHQDD6pAcz5ELQABjGgAdz/2ZzQuRHXY0ZnlEIc8Q0wsQ5XcAXc+RAPsA2cgALvGQvbsAbiOZ4aIZ0UIQysxhG5CBOacAMFAJ/OSW1QABOHUACQsAEw8QaPgKAZwU7oyZtvmBH4CRNs8AJwcKDxuRABoAUwwQRwEA0wwQPoYKAUahF1gBgYcTXVhBExwAmUNgG2AKIJehAa8GI8MAzDQGaMsAA30AUhWhEHkERVxArECREBAAbbwAPQIAXmABOMkKMtehAxQKIwgQEwABPaABP7sAAHuqPykwpFiBHJ4JsXkQMw4QNDUAICYAU8sA2MwAQF8Aj8SRABcAuaN2wfUAzboA0lsAc3AJ8WcRgcIQtz/3kRAaB5NLAHNhCmc0AGKfoCRYqgATAC8HAPa2CjKToD8bIM7HBwPyAAQwAHRmqmDnEAp2CdFIE+TcoQugATNFCnZPYBMQEKJACiGlCjwzYDudAG2ZAN17AN13AJqPqhWfoQ7FQ9GzE6s5oQOWCjjEBmuTADQSAAX5qiPkACXQCftUppuMpuNOAO4XqkDdEKMAoSv8CmTqp5PJAOGKANy7ALl/AFP9AHfdCtVloA4XoFELoNkxATuAYTucAFekBmPJCn6roQglKZH1EJp/AAEUltUMoDL8AD4tAHl6AHuPoMAiAJH4CrjPChXZCymjAM/gAT16ACQgATd9AGPNALH/9gBzYAAsz6sAhRB8gxmhdxQ2nKEPPJCehAD9sQqOUKE3YgACXwtEOwByibsjcwDIMXpUYAE76QAFxwDdfwBU4rtTraENuCnCgBIg8RCqewCHCQDuSaopZQAkMQtXtApHl6BV2AC7h6rBO4Db4gB2S2C4W6s6xaEK5qth5xMEOLEAGQAyuwAjdACTABA19wCcsAE8UQtgsAB6sEsO85DmT2BQmQAICborkAE1ZQqEXKswYhA9+iEwcTUSIaAHh7A3CAq32gCjHRB6hqtykLn+I5rnX6Bfx6rLmwC6SLrE5LpHpauAJRGI2aFWJCJtSmAbUrDZMbEzygrIaaruLZnCj/oAPuEAnbIA7O9AzbMAdBcKzbcKqpWqaEgRyIOxI3BK8HwZzW2wXuMGw8MAYlQKaaOhABYL03MAXbUAZPKwXDJgn/ewPNmxB1oCjzG4KmcpsGwZx4Cwo8YAPO9AP+K7WrahDWWwAvsA1TQLfkCwMz8AFksKzwixB8cClAWxJnEQgXSxAjDAd7EKdyK7bNKhAD3AUFkAY+sLlw8A6UsAdPK7dEGsKGox2miT5ocMNAPMK2uwCby6Ksm5QaIMRhVwAFcMV7ULeZyrM0yAnQOh/1gY6Mm79gDMbp2p1t/J4pW8dh3LlxXBB1EAgzAavGQTUOYMECLJ7v+Z7f67xVvJ+Es1zIhfywfOAKnLC4sVkJHiAI28G45FmeDJHJ+KvIcpwjq3HJxVkQl2HJ0woS4YAcxDHKCXEZ4DHBG1EHwqAoq8zKC/EXXyEGfnwRrSAGrGDJsGzLxNcVnLArpzxX/CMIeyHME8EVXpEKDhAXZCEDwbYNabHLzJxYPcF8gpAKoeAAD3AAMtMKuBUOUXQAD0AppyAIVGEVM5zNwrlILfESlDYTVWETwQzP+rzP/NzP/vzPOREQADs=",
                LogoUrl =
                @"data:image/png;base64,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",
                ReceiptInfoInputs = new List<BatchPortraitReceiptInfoDto>()
            };

            for (var i = 0; i < 500; i++)
                input.ReceiptInfoInputs.Add(new BatchPortraitReceiptInfoDto
                {
                    Amount = 22939.43M,
                    Grade = "2019秋",
                    IdNo = "43062619890622xxxx",
                    Name = "张三",
                    PaymentMethod = "微信支付",
                    Profession = "运动训练",
                    Remark = "学费",
                    TradeStatus = "已完成",
                    TradeTime = DateTime.Now,
                    UppercaseAmount = "贰万贰仟玖佰叁拾玖圆肆角叁分",
                    Code = "1907180000" + i
                });
            return input;
        }


        [HttpGet("Html")]
        [Magicodes(Type = typeof(ReceiptInfo), TemplatePath = ".//ExportTemplates//receipt.cshtml")]
        public ReceiptInfo Html()
        {
            return new ReceiptInfo
            {
                Amount = 22939.43M,
                Grade = "2019秋",
                IdNo = "43062619890622xxxx",
                Name = "张三",
                Payee = "湖南心莱信息科技有限公司",
                PaymentMethod = "微信支付",
                Profession = "运动训练",
                Remark = "学费",
                TradeStatus = "已完成",
                TradeTime = DateTime.Now,
                UppercaseAmount = "贰万贰仟玖佰叁拾玖圆肆角叁分",
                Code = "19071800001"
            };
        }
        [HttpGet("Word")]
        [Magicodes(Type = typeof(ReceiptInfo), TemplatePath = ".//ExportTemplates//receipt.cshtml")]
        public ReceiptInfo Word()
        {
            return new ReceiptInfo
            {
                Amount = 22939.43M,
                Grade = "2019秋",
                IdNo = "43062619890622xxxx",
                Name = "张三",
                Payee = "湖南心莱信息科技有限公司",
                PaymentMethod = "微信支付",
                Profession = "运动训练",
                Remark = "学费",
                TradeStatus = "已完成",
                TradeTime = DateTime.Now,
                UppercaseAmount = "贰万贰仟玖佰叁拾玖圆肆角叁分",
                Code = "19071800001"
            };
        }
    }
}
