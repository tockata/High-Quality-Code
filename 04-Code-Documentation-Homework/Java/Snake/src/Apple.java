import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

/**
 * Class that creates apple, draws it and holds its position
 */
public class Apple {
	public static Random random;
	private Point applePosition;
	private Color appleColor;

    /**
     * Apple constructor
     * @param snake Snake object instance
     * @see Snake
     */
	public Apple(Snake snake) {
		applePosition = createApple(snake);
		appleColor = Color.RED;
	}

    /**
     * Creates apple coordinates
     * @param snake Snake object instance
     * @return Point
     */
	private Point createApple(Snake snake) {
		random = new Random();
		int x = random.nextInt(30) * 20;
		int y = random.nextInt(30) * 20;
		for (Point snakeElement : snake.body) {
			if (x == snakeElement.getX() || y == snakeElement.getY()) {
				return createApple(snake);
			}
		}

		return new Point(x, y);
	}

    /**
     * Draws apple at given position
     * @param g Instance of Graphics Class
     */
	public void drawApple(Graphics g){
		applePosition.drawSquareFromPoint(g, appleColor);
	}

    /**
     *
     * @return Position of Apple
     */
	public Point getApplePosition(){
		return applePosition;
	}
}
