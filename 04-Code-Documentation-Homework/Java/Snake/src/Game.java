import java.awt.Canvas;
import java.awt.Dimension;
import java.awt.Graphics;

/**
 * Main class that runs the game.
 */
@SuppressWarnings("serial")
public class Game extends Canvas implements Runnable {
	public static Snake snake;
	public static Apple apple;
	static int score;
	
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension gameFieldSize = new Dimension(WIDTH, HEIGHT);
	
	static boolean gameRunning = false;

    /**
     * Creates graphic and opens thread for application
     * @param g
     */
	public void paint(Graphics g){
		this.setPreferredSize(gameFieldSize);
		globalGraphics = g.create();
		score = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}

    /**
     * Infinite cycle running the game and sleeps it for given interval
     */
	public void run(){
		while(gameRunning){
			snake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: catch me for the exception
			}
		}
	}

    /**
     * Class constructor
     */
	public Game(){
        snake = new Snake();
        apple = new Apple(snake);
    }

    /**
     * Graphic renderer
     * @param g
     */
	public void render(Graphics g){
		g.clearRect(0, 0, WIDTH, HEIGHT +25);
		
		g.drawRect(0, 0, WIDTH, HEIGHT);
		snake.drawSnake(g);
		apple.drawApple(g);
		g.drawString("score= " + score, 10, HEIGHT + 25);
	}
}

