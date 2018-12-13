using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace AdventOfCodeSolvings
{


    public class Day13 : DayInterface<string, int>
    {
        List<Cart> cartList = new List<Cart>();
        public string RunPartA(List<string> input)
        {
            char[,] locMap = new char[input.Count, input[0].Length];
            for(var y = 0; y < input.Count; y++)
            {
                var charArr = input[y].ToCharArray(); Debug.WriteLine("");
                for (var x = 0; x < input[y].Length; x++)
                {
                    Debug.Write(charArr[x]);
                    locMap[y,x] = charArr[x];
                    if(charArr[x] == '<' || charArr[x] == '>' || charArr[x] == 'v' || charArr[x] == '^')
                    {
                        char currentReplacingChar = char.MinValue;
                        if(charArr[x] == '<' || charArr[x] == '>')
                        {
                            currentReplacingChar = '-';
                        }
                        else
                        {
                            currentReplacingChar = '|';
                        }
                        var newCart = new Cart()
                        {
                            positionX = x,
                            positionY = y,
                            currentMove = charArr[x],
                            ReplacingChar = currentReplacingChar,
                        };
                        cartList.Add(newCart);
                    }
                }
            }

            bool notCrash = true;
            while (notCrash)
            {
                foreach (var cart in cartList)
                {
                    Debug.WriteLine("current pos " + cart.positionX + " " + cart.positionY + " cur " + cart.currentMove + " " + cart.ReplacingChar);

                    for(var xa = 0; xa < 13; xa++)
                    {
                        Debug.WriteLine("");
                        for (var ya = 0; ya < 6; ya++)
                        {
                            Debug.Write(locMap[ya, xa]);
                        }
                    }
                    Debug.WriteLine("");
                    var nextChar = char.MinValue;
                    int nextPosX = cart.positionX, nextPosY = cart.positionY;
                    switch (cart.currentMove)
                    {
                        case '>':
                            nextChar = locMap[cart.positionX + 1, cart.positionY];
                            nextPosX++;
                            break;
                        case '<':
                            nextChar = locMap[cart.positionX - 1, cart.positionY];
                            nextPosX--;
                            break;
                        case '^':
                            nextChar = locMap[cart.positionX, cart.positionY - 1];
                            nextPosY--;
                            break;
                        case 'V':
                            nextChar = locMap[cart.positionX, cart.positionY + 1];
                            nextPosY++;
                            break;
                    }
                    switch (nextChar)
                    {
                        case '<':
                        case '>':
                        case '^':
                        case 'V':
                            return "crash at " + nextPosX + " - " + nextPosY;
                        case '/':
                            if(cart.currentMove == '<')
                            {
                                locMap[nextPosX, nextPosY] = 'V';
                            }
                            else
                            {
                                locMap[nextPosX, nextPosY] = '>';
                            }
                            break;
                        case '\\':
                            if (cart.currentMove == '>')
                            {
                                locMap[nextPosX, nextPosY] = '^';
                            }
                            else
                            {
                                locMap[nextPosX, nextPosY] = '<';
                            }
                            break;
                        case '+':
                            if (cart.currentMove == '>')
                            {
                                switch (cart.intersectionAction)
                                {
                                    case 0:
                                        locMap[nextPosX, nextPosY] = '^';
                                        break;
                                    case 1:
                                        locMap[nextPosX, nextPosY] = '>';
                                        break;
                                    case 2:
                                        locMap[nextPosX, nextPosY] = 'V';
                                        break;
                                }
                            }
                            else if(cart.currentMove == 'V')
                            {
                                switch (cart.intersectionAction)
                                {
                                    case 0:
                                        locMap[nextPosX, nextPosY] = '>';
                                        break;
                                    case 1:
                                        locMap[nextPosX, nextPosY] = 'V';
                                        break;
                                    case 2:
                                        locMap[nextPosX, nextPosY] = '<';
                                        break;
                                }
                            }
                            else if (cart.currentMove == '<')
                            {
                                switch (cart.intersectionAction)
                                {
                                    case 0:
                                        locMap[nextPosX, nextPosY] = 'V';
                                        break;
                                    case 1:
                                        locMap[nextPosX, nextPosY] = '<';
                                        break;
                                    case 2:
                                        locMap[nextPosX, nextPosY] = '^';
                                        break;
                                }
                            }
                            else if (cart.currentMove == '^')
                            {
                                switch (cart.intersectionAction)
                                {
                                    case 0:
                                        locMap[nextPosX, nextPosY] = '<';
                                        break;
                                    case 1:
                                        locMap[nextPosX, nextPosY] = '^';
                                        break;
                                    case 2:
                                        locMap[nextPosX, nextPosY] = '>';
                                        break;
                                }
                            }
                            break;
                        case '|':
                        case '-':
                        default:
                            locMap[nextPosX, nextPosY] = cart.currentMove;
                            
                            break;
                    }
                    locMap[cart.positionX, cart.positionY] = cart.ReplacingChar;
                    cart.positionX = nextPosX;
                    cart.positionY = nextPosY;
                    cart.ReplacingChar = nextChar;
                }
            }
            return "No crash";
        }

        public int RunPartB(List<string> input)
        {

            return -1;
        }
    }

    public class Cart
    {
        public char currentMove = char.MinValue;
        public int intersectionAction = 0;
        public int positionX = 0;
        public int positionY = 0;
        public char ReplacingChar = char.MinValue;
    }
}
