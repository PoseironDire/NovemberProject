using System;
using System.Numerics;
using Raylib_cs;

namespace Visual
{
    class Program
    {
        static void Main(string[] args)
        {

            //Window size
            int w = 1800;
            int h = 1000;

            //Player positions
            float speedX = w / 2 - 200;
            float speedY = h / 2;
            float speedX2 = w / 2 + 200;
            float speedY2 = h / 2;

            //Player size
            int playerSize = 25;
            int player2Size = 25;

            //Radar size
            int playerRadarSize = 100;

            //Player speed
            float speedP1 = 10.5f;
            float speedP2 = 7.5f;

            //Player states
            string p1 = "idle";

            //Game states
            string scene = "intro";
            string selector = "play";

            //Counter
            int counter = 1;
            
            //Delays
            int enterDelay = 0;

            //Colors
            Color menuBG = new Color(100, 200, 140, 255);
            Color guideBG = new Color(200, 50, 20, 255);
            Color exitBG = new Color(50, 50, 50, 255);
            Color gameBG = new Color(100, 250, 40, 255);

            Color darkgrey = new Color(150, 150, 150, 255);
            Color yellow = new Color(200, 200, 20, 255);
            Color red = new Color(200, 10, 10, 255);

            Color activeButtonColor = new Color(0, 20, 250, 255);

            Color currentButtonColor = darkgrey;
            Color buttonColor = currentButtonColor;

            Color button = buttonColor;
            Color button2 = buttonColor;
            Color button3 = buttonColor;
            Color button4 = buttonColor;
            
            //Game Setup
            Raylib.InitWindow(w, h, "");
            Raylib.SetTargetFPS(60);
            Raylib.SetExitKey(0);
            Raylib.SetWindowTitle("A Game Created By Esvin");
            Image icon = Raylib.LoadImage(@"Smiley.png");
            Raylib.SetWindowIcon(icon);

            while (!Raylib.WindowShouldClose())
            {
                //INTRO
                if (scene == "intro")
                {
                    Raylib.ClearBackground(menuBG);
                    Raylib.DrawText("Welcome To A Game!", w / 4, h / 2 - 50, 100, Color.WHITE);
                    Raylib.DrawText("Press ENTER To Play!", w / 4 +200, h / 2 + 50, 45, Color.WHITE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "menu";
                    }
                }

                //MENU
                else if (scene == "menu")
                {
                    //Used to delay the ENTER Button
                    enterDelay += 1;

                    buttonColor = currentButtonColor;

                    //Menu Selection Functions
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
                    {
                        counter -= 1;
                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
                    {
                        counter += 1;
                    }

                    if (counter < 1)
                    {
                        counter = 3;
                    }
                    if (counter > 3)
                    {
                        counter = 1;
                    }

                    if (counter == 1)
                    {
                        selector = "play";
                        Raylib.ClearBackground(menuBG);
                        currentButtonColor = darkgrey;
                        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && enterDelay > 9)
                        {
                            scene = "game";
                        }
                    }
                    else if (counter == 2)
                    {
                        selector = "guide";
                        Raylib.ClearBackground(guideBG);
                        currentButtonColor = yellow;
                         if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && enterDelay > 9)
                        {
                            scene = "guide";
                        }
                    }
                    else if (counter == 3)
                    {
                        selector = "exit";
                        Raylib.ClearBackground(exitBG);
                        currentButtonColor = red;
                         if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER) && enterDelay > 9)
                        {
                            Raylib.CloseWindow();
                        }
                    }
                    
                    //Button Colors
                    if(selector == "play")
                    {
                        button = activeButtonColor;
                    }
                    else
                    {
                        button = buttonColor;
                    }
                     if(selector == "guide")
                    {
                        button2 = activeButtonColor;
                    }
                    else
                    {
                        button2 = buttonColor;
                    }
                     if(selector == "exit")
                    {
                        button3 = activeButtonColor;
                    }
                    else
                    {
                        button3 = buttonColor;
                    }

                    Raylib.DrawRectangle(w/2-300,h/2-75,600,50, button);
                    Raylib.DrawText("PLAY",w/2-75,h/2-75,50, Color.WHITE);
                    Raylib.DrawRectangle(w/2-300,h/2,600,50, button2);
                    Raylib.DrawText("GUIDE",w/2-75,h/2,50, Color.WHITE);
                    Raylib.DrawRectangle(w/2-300,h/2+75,600,50, button3);
                    Raylib.DrawText("EXIT",w/2-75,h/2+75,50, Color.WHITE);
                }

                //GUIDE
                else if (scene == "guide")
                {
                    Raylib.ClearBackground(guideBG);
                    Raylib.DrawText("P1 (blue) Seeker: w,a,s,d", w/2-300, h / 2 - 100, 50, Color.WHITE);
                    Raylib.DrawText("P2 (red) Runner: i,j,k,l", w/2-300, h / 2, 50, Color.WHITE);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE) || Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "menu";
                    }

                //GAME    
                }
                else if (scene == "game")
                {
                    Raylib.ClearBackground(gameBG);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
                    {
                        scene = "gameMenu";
                        enterDelay = 0;
                    }

                    if (p1 == "moving")
                    {
                        playerRadarSize = 70;
                    }
                    else 
                    {
                        playerRadarSize = 100;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_D))
                    {
                        p1 = "moving";
                    }
                    else
                    {
                        p1 = "idle";
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                    {
                        speedP2 = 15.5f;
                    }
                    else
                    {
                        speedP2 = 7.5f;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                    {
                        speedX += speedP1;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                    {
                        speedX -= speedP1;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                    {
                        speedY -= speedP1;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                    {
                        speedY += speedP1;
                    }
                    if (speedX <= 0 + playerSize)
                    {
                        speedX = 0 + playerSize;
                    }
                    if (speedX >= w - playerSize)
                    {
                        speedX = w - playerSize;
                    }
                    if (speedY <= 0 + playerSize)
                    {
                        speedY = 0 + playerSize;
                    }
                    if (speedY >= h - playerSize)
                    {
                        speedY = h - playerSize;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_L) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        speedX2 += speedP2;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_J) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        speedX2 -= speedP2;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_I) || Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    {
                        speedY2 -= speedP2;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_K) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    {
                        speedY2 += speedP2;
                    }
                    if (speedX2 <= 0 + player2Size)
                    {
                        speedX2 = 0 + player2Size;
                    }
                    if (speedX2 >= w - player2Size)
                    {
                        speedX2 = w - player2Size;
                    }
                    if (speedY2 <= 0 + player2Size)
                    {
                        speedY2 = 0 + player2Size;
                    }
                    if (speedY2 >= h - player2Size)
                    {
                        speedY2 = h - player2Size;
                    }
        
                    Raylib.BeginDrawing();

                    Color purpleRadar = new Color(123, 30, 230, 150);
                    Color grayish = new Color(200, 200, 200, 200);

                    Raylib.ClearBackground(Color.DARKGRAY);

                    Raylib.DrawRectangle(30, 30, w - 60, h - 60, grayish);

                    Raylib.DrawRectangle(0, 400, 20, h - 800, Color.RED);

                    Raylib.DrawCircle((int)speedX2, (int)speedY2, playerSize, Color.RED);
                    Raylib.DrawCircle((int)speedX, (int)speedY, playerRadarSize, purpleRadar);

                    Raylib.DrawCircle((int)speedX, (int)speedY, playerSize, Color.BLUE);

                    if (speedX2 < 26 && speedY2 < 601 && speedY2 > 399)
                    {
                        scene = "p2win";
                    }
                    if (speedX > speedX2-playerSize && speedX < speedX2+playerSize && speedY > speedY2-playerSize && speedY < speedY2+playerSize)
                    {
                        scene = "p1win";
                    }
                }
                //INGAME MENU
                if (scene == "gameMenu")
                {
                    enterDelay += 1;

                    Color graymenu = new Color(50, 50, 50, 100);

                    Raylib.DrawRectangle(0, 0, w, 150, graymenu);
                    Raylib.DrawRectangle(0, h - 150, w, h, graymenu);
                    Raylib.DrawText("Menu Sceen", w/2-250, h / 2 - 50, 100, Color.WHITE);
                    Raylib.DrawText("R: Restart", w/2-100, h / 2 + 50, 50, Color.WHITE);
                    Raylib.DrawText("E: Exit", w/2-100, h / 2 + 100, 50, Color.WHITE);


                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
                    {
                        Raylib.CloseWindow();
                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE) || Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE) && enterDelay > 10)
                    {
                        scene = "game";
                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                    {
                        scene = "menu";

                        speedX = w / 2 - 200;
                        speedY = h / 2;
                        speedX2 = w / 2 + 200;
                        speedY2 = h / 2;
                        enterDelay = 0;
                    }
                }
                //PLAYER 1 VICTORY SCREEN
                else if (scene == "p1win")
                {
                    Raylib.ClearBackground(Color.BLUE);
                    Raylib.DrawText("BLUE WON!", w/2-250, h / 2 - 50, 100, Color.WHITE);
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_E) || Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
                    {
                        Raylib.CloseWindow();
                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                    {
                        scene = "menu";

                        speedX = w / 2 - 200;
                        speedY = h / 2;
                        speedX2 = w / 2 + 200;
                        speedY2 = h / 2;
                        enterDelay = 0;
                    }
                }
                //PLAYER 2 VICTORY SCREEN
                else if (scene == "p2win")
                {
                    Raylib.ClearBackground(Color.RED);
                    Raylib.DrawText("RED WON!", w/2-250, h / 2 - 50, 100, Color.WHITE);
                      if (Raylib.IsKeyPressed(KeyboardKey.KEY_E) || Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
                    {
                        Raylib.CloseWindow();
                    }
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                    {
                        scene = "menu";

                        speedX = w / 2 - 200;
                        speedY = h / 2;
                        speedX2 = w / 2 + 200;
                        speedY2 = h / 2;
                        enterDelay = 0;
                    }
                }
                Raylib.EndDrawing();
            }
        }
    }
}
